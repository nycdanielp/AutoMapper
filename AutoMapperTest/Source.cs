using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class Source
    {
        public string FirstName;
        public string LastName;
        public SourceAddress sourceAddress;
    }

    public class SourceAddress
    {
        public string Zip;
        public string Street;
        public string State;
    }
}