using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratzDotNet.Models.GraphQl;
using StratzDotNetTest.TestModels;

namespace StratzDotNetTest
{
    // I really don't like graphql
    [TestClass]
    public class GraphQlTest
    {
        private StratzCaller GenerateCaller()
        {
            return new StratzCaller("", true);
        }

        [TestMethod]
        public void TestMatchCall()
        {
            using (var caller = GenerateCaller())
            {
                var queryParams = new Dictionary<string, object>();

                queryParams.Add("id", 6599024921);

                var matchResponse = caller.Query<MatchResponse>("match", queryParams).Result;

                Assert.AreEqual(true, matchResponse.Match.DidRadiantWin);
                Assert.AreEqual(732, matchResponse.Match.DurationSeconds);
            }
        }

        [TestMethod]
        public void TestMatchCallIgnoreAttribute()
        {
            using (var caller = GenerateCaller())
            {
                var queryParams = new Dictionary<string, object>();

                queryParams.Add("id", 6599024921);

                var matchResponse = caller.Query<MatchResponse>("match", queryParams).Result;

                Assert.AreEqual(true, matchResponse.Match.DidRadiantWin);
                Assert.AreEqual(732, matchResponse.Match.DurationSeconds);
                // 0 would be the default value of NumHumanPlayers
                // this is an overall issue with our approach 
                // -> if we forget to request the property or there's an issue in retrieving it 
                // and it doesn't get mapped, we might assume the default is the correct response
                Assert.AreEqual(0, matchResponse.Match.NumHumanPlayers);
            }
        }

        [TestMethod]
        public void TestMatchCallJsonPropertyAttribute()
        {
            using (var caller = GenerateCaller())
            {
                var queryParams = new Dictionary<string, object>();

                queryParams.Add("id", 6599024921);

                var matchResponse = caller.Query<MatchResponse>("match", queryParams).Result;

                // this actually works when ingesting the response, sweet
                Assert.AreEqual("ALL_PICK_RANKED", matchResponse.Match.DotaGameMode);
            }
        }

    }
}