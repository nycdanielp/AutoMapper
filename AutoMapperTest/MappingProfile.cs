using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(s => s.addresses, c => c.MapFrom(m => m.sourceAddress));
            CreateMap<SourceAddress, Address>();
            CreateMap<SourceAddress, Zipcode>();
            CreateMap<SourceAddress, IEnumerable<Address>>()
                .ConvertUsing<AddressConverter>();
        }
    }

    class AddressConverter : ITypeConverter<SourceAddress, IEnumerable<Address>>
    {
        public IEnumerable<Address> Convert(SourceAddress source, IEnumerable<Address> destination, ResolutionContext context)
        {
            IList<Address> address = new List<Address>();
            Address newAddress = context.Mapper.Map<SourceAddress, Address>(source);
            newAddress.zipcode = context.Mapper.Map<SourceAddress, Zipcode>(source);
            address.Add(newAddress);
            return address;
        }
    }
}