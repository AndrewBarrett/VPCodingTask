using AutoMapper;
using BAS.VPTask.Core.DTOs.Customer;
using BAS.VPTask.Core.DTOs.Item;
using BAS.VPTask.Core.Entities;

namespace BAS.VPTask.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<ItemDto, ItemOrder>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}