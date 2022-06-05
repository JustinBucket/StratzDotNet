using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StratzDotNet.Models.GraphQl;

namespace StratzDotNetTest.TestModels
{
    public class MatchResponse : GraphQlResponseObject
    {
        public Match Match { get; set; }
    }
}