using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StratzDotNet.Models.GraphQl
{
    public class TestResponse
    {
        // this is idiotic
        // why do I have to create this useless object when I'm using GraphQL's own libraries?
        // Can't it parse this out?
        public Match Match { get; set; }
    }
}