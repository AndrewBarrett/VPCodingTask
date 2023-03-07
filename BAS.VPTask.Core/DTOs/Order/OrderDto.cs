using BAS.VPTask.Core.DTOs.Customer;
using BAS.VPTask.Core.DTOs.Item;

namespace BAS.VPTask.Core.DTOs.Order
{
    public sealed class OrderDto
    {
        public CustomerDto CustomerDto { get; set; } = new();
        public List<ItemDto> ItemDtoList { get; set; } = new();
    }
}