using System.Net.Mail;
using BAS.VPTask.Core.DTOs.Customer;
using BAS.VPTask.Core.DTOs.Item;
using BAS.VPTask.Core.DTOs.Order;
using BAS.VPTask.Core.Entities;
using BAS.VPTask.EntityFramework.Interfaces;

namespace BAS.VPTask.Application.Services
{
    public class OrderValidationService
    {
        private readonly IItemRepository _itemRepository;

        public OrderValidationService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        protected void ValidateCustomer(CustomerDto customer, OrderResultDto orderResultDto)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                orderResultDto.ErrorMessages.Add("Customer name cannot be empty.");
            }

            if (customer.Name.Length > 256)
            {
                orderResultDto.ErrorMessages.Add("Customer name cannot exceed 256 characters.");
            }

            if (!MailAddress.TryCreate(customer.Email, out MailAddress? mailAddress))
            {
                orderResultDto.ErrorMessages.Add("Email address is invalid.");
            }
        }

        protected async Task ValidateItems(List<ItemDto> itemDtoList, OrderResultDto orderResultDto)
        {
            if (itemDtoList.Count <= 0)
            {
                orderResultDto.ErrorMessages.Add("Item list is empty.");
                return;
            }

            List<Guid> itemIdList = itemDtoList.Select(x => x.Id).ToList();
            List<ItemStock> itemStockList = await _itemRepository.FetchItemListByIdAsync(itemIdList);

            foreach (ItemDto itemDto in itemDtoList)
            {
                ItemStock? item = itemStockList.FirstOrDefault(x => x.Id == itemDto.Id);

                if (item == null)
                {
                    orderResultDto.ErrorMessages.Add($"Could not find item: {itemDto.Name}.");
                }
                else if (item.CurrentStock < itemDto.Quantity)
                {
                    orderResultDto.ErrorMessages.Add($"Insufficient stock: {itemDto.Name}.");
                }
            }
        }
    }
}