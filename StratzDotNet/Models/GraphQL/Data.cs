using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StratzDotNet.Models.GraphQl
{
    public class Data<T>
    {
        public T Result { get; set; }
    }
}