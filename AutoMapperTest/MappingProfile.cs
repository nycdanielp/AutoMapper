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
            // Add as many of these lines as you need to map your objects
            CreateMap<Source, Destination>()
                .ForMember(s => s.addresses, c => c.MapFrom(m => m.sourceAddress));
            CreateMap<SourceAddress, Address>();
        }
    }
}