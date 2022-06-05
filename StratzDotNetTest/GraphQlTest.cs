using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratzDotNet.Models.GraphQl;

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
        public void TestTestCall()
        {
            using (var caller = GenerateCaller())
            {
                var testResponse = caller.TestMethod().Result;

                Assert.AreEqual(732, testResponse.Match.DurationSeconds);
            }

        }

    }
}