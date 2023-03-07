using BAS.VPTask.Application.Interfaces;
using BAS.VPTask.Core.DTOs.Order;
using BAS.VPTask.EntityFramework.Interfaces;

namespace BAS.VPTask.Application.Services
{
    public sealed class OrderService : OrderValidationService, IOrderService
    {
        private readonly ICustomerRepository _customerRepository;

        public OrderService(ICustomerRepository customerRepository,
                            IItemRepository itemRepository)
            : base(itemRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<OrderResultDto> CreateGuestOrderAsync(OrderDto orderDto)
        {
            OrderResultDto orderResultDto = new(true);

            try
            {
                await ValidateOrderDtoAsync(orderResultDto, orderDto);

                if(!orderResultDto.Success)
                {
                    return orderResultDto;
                }

                await _customerRepository.CreateGuestOrderAsync(orderDto);
            }
            catch (Exception ex)
            {
                orderResultDto.Success = false;
                orderResultDto.ErrorMessages.Add("There was an error when creating the order.");
            }

            return orderResultDto;
        }

        private async Task ValidateOrderDtoAsync(OrderResultDto orderResultDto, OrderDto orderDto)
        {
            ValidateCustomer(orderDto.CustomerDto, orderResultDto);
            await ValidateItems(orderDto.ItemDtoList, orderResultDto);

            orderResultDto.Success = !(orderResultDto.ErrorMessages.Count > 0);
        }
    }
}