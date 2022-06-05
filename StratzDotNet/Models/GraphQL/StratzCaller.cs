using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace StratzDotNet.Models.GraphQl
{
    public sealed class StratzCaller : GraphQLHttpClient
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings();
        public StratzCaller(string apiKey, bool enableJsonTrace = false) 
            : base(new Uri("https://api.stratz.com/graphql"), new NewtonsoftJsonSerializer())
        {

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                apiKey = Helpers.GetApiKey().Result;
            }

            if (enableJsonTrace)
            {
                ITraceWriter traceWriter = new MemoryTraceWriter();
                _serializerSettings.TraceWriter = traceWriter;
                _serializerSettings.Converters.Add(new JavaScriptDateTimeConverter());
            }

            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

        }

        private string[] RetrieveRequestedFields<T>()
        {
            var parentProperties = typeof(T).GetProperties();

            if (parentProperties.Length != 1)
            {
                throw new InvalidParentResponseObjectException($"type {typeof(T).Name} should contain only a single property that is the expected data type");
            }

            var childObjectType = parentProperties[0].PropertyType;
            var childProperties = childObjectType.GetProperties();

            var requestedFields = new string[] { };

            foreach (var i in childProperties)
            {
                // var hasIsIdentity = Attribute.IsDefined(pi, typeof(IsIdentity));
                var ignoreDefined = Attribute.IsDefined(i, typeof(IgnoreAttribute));

                if (!ignoreDefined)
                {
                    var jsonPropDefined = Attribute.IsDefined(i, typeof(JsonPropertyAttribute));

                    if (jsonPropDefined)
                    {
                        // going to assume only one
                        var attributes = (JsonPropertyAttribute[])i.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                        
                        requestedFields = requestedFields.Append(attributes[0].PropertyName).ToArray();
                    }
                    else
                    {
                        requestedFields = requestedFields.Append(i.Name).ToArray();
                    }
                }
            }

            return requestedFields;
        }
        

        private string GenerateQueryText(string endpoint, Dictionary<string, object> parameters, string[] requestedFields)
        {
            var requestedFieldsString = GenerateRequestedFieldsString(requestedFields);

            var parameterString = GenerateParameterString(parameters);

            // need a better way to do this
            var queryString = "{" + endpoint + "(" + parameterString + "){" + requestedFieldsString + "}}"; 

            return queryString;
        }

        private string GenerateParameterString(Dictionary<string, object> parameters)
        {
            var parameterFields = new string[] { };

            foreach (var i in parameters)
            {
                parameterFields = parameterFields.Append($"{i.Key}: {i.Value}").ToArray();   
            }

            var parameterString = string.Join(", ", parameterFields);

            return parameterString;
        }

        private string GenerateRequestedFieldsString(string[] requestedFields)
        {
            var formattedFields = new string[] {};
            foreach (var i in requestedFields)
            {
                // need to turn these to camel case because graphql is incapable of handling I guess
                var firstChar = i[0].ToString().ToLower();
                var restOfString = string.Join("", i.Skip(1));

                formattedFields = formattedFields.Append(firstChar + restOfString).ToArray();
            }
            
            var requestFieldsString = string.Join(", ", formattedFields);

            return requestFieldsString;
        }

        public async Task<T> Query<T>(string endpoint, Dictionary<string, object> parameters) where T: GraphQlResponseObject
        {
            // it's no longer the 'T' type, but the type of the property defined in it
            // makes it kinda tricky
            var requestedFields = RetrieveRequestedFields<T>();
            var queryText = GenerateQueryText(endpoint, parameters, requestedFields);

            var query = new GraphQLRequest
            {
                Query = queryText
            };

            var response = await SendQueryAsync<T>(query);

            // I now need to find a way to deserialize the returned object.
            // there's only so many 'endpoints' I could manually create it
            // if we create classes for them, all under the a shared type?
            // that would restrict the user to only what we've built out, if stratz adds capabilities, user won't have access to them
            // just create the parent class?

            if (response.Errors != null)
            {
                var errorTexts = new string[] {};
                foreach (var i in response.Errors)
                {
                    errorTexts = errorTexts.Append(i.Message).ToArray();
                }

                var errorMessage = string.Join(Environment.NewLine, errorTexts);

                throw new GraphQlRequestException(errorMessage);
            }

            return response.Data;
        }

    }

}