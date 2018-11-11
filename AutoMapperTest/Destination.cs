using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class Destination
    {
        public IEnumerable<Address> addresses;
        public string FirstName;
        public string LastName;
    }

    public class Address
    {
        public string Street;
        public string State;
        public Zipcode zipcode;
    }

    public class Zipcode
    {
        public string Zip;
    }
}
