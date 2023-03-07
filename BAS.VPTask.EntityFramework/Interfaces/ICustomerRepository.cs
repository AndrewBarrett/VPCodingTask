using BAS.VPTask.Core.DTOs.Order;
using BAS.VPTask.Core.Entities;

namespace BAS.VPTask.EntityFramework.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateGuestOrderAsync(OrderDto orderDto);
    }
}