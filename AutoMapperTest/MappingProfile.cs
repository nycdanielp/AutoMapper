using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapperTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(s => s.addresses, c => c.MapFrom(m => m.sourceAddress));

            // If you do anything custom, you can't use ReverseMap
            CreateMap<Destination, Source>()
                .ForMember(s => s.sourceAddress, c => c.MapFrom(m => m.addresses.FirstOrDefault()))
                .ForPath(s => s.sourceAddress.Zip, c => c.MapFrom(m => m.addresses.FirstOrDefault().zipcode.Zip));

            CreateMap<SourceAddress, Address>()
                .ReverseMap();
            CreateMap<SourceAddress, Zipcode>()
                .ReverseMap();
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