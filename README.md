
# StratzDotNet

This library aims to provide a wrapper for the Stratz GraphQL API in C#.

## GraphQL vs REST

There is the outline of me mapping out the REST api, but since it's not supported anymore, I'm stopping development. I'm leaving it in for now but will likely remove it when I get around to it.

## How to use

### Rest

Create a new Rest.StratzCaller instance, passing in your API key.
The StratzCaller object will have specific methods that map to the REST API.

### GraphQL

Create a new GraphQl.StratzCaller instance, passing in your API key.
There is some additional work required on your end to be able to query the api.
Because of the way GraphQL returns data, and the way it's parsed by the GraphQLHttpClient, you will need to create dumb objects to hold the objects you actually care about. You can see how I do this in the GraphQlTest class. That "dumb" object should contain a single property that matches what the data you want returned by the API - and nothing else. You call it whatever you like, but it has to inherit from GraphQlResponseObject.
When calling the StratzCaller.Query method, pass the type argument as the dumb object that inherits from GraphQlResponseObject.
The Query method will look at the property in the dumb object, get its type, and pull all the properties from that object to add as subFields.
If you want a property to be ignored when creating the query you can add the IgnoreAttribute to that property
If you want to name a property differently than what the subField is called in the API, you can use the JsonProperty attribute.

## Examples

The test project should have some examples for you to get started with