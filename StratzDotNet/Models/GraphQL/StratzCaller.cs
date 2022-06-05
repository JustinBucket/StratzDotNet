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
    public class StratzCaller : GraphQLHttpClient
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

        private string GenerateQueryText(string endpoint, Dictionary<string, object> parameters, string[] requestedFields)
        {
            var queryTemplate = File.ReadAllText("QueryTextTemplate");
            var query = string.Format(queryTemplate, );
        }

        public async Task<TestResponse> TestMethod()
        {

            var query = new GraphQLRequest
            {
                Query = @"{
                            match(id: 6599024921){
                                durationSeconds
                            }
                        }"
            };
            
            var response = await SendQueryAsync<TestResponse>(query);

            return response.Data;
        }

        public async Task<T> Query<T>(Dictionary<string, object> parameters)
        {


            throw new NotImplementedException();
        }

    }

}