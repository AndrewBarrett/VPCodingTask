using AutoMapper;
using BAS.VPTask.Core.DTOs.Item;

namespace BAS.VPTask.Core.Entities
{
    public sealed class Order
    {
        public Order()
        {
        }

        public Order(List<ItemDto> itemDtoList, List<ItemStock> itemStockList, IMapper mapper)
        {
            TotalCost = CalculateOrderCost(itemDtoList, itemStockList);
            AddItemsToList(itemDtoList, itemStockList, mapper);
        }

        public Guid Id { get; set; }
        public Customer Customer { get; set; } = new();
        public Guid CustomerId { get; set; } = new();
        public List<ItemOrder> Items { get; set; } = new();
        public decimal TotalCost { get; set; } = new();

        private decimal CalculateOrderCost(List<ItemDto> ItemDtoList, List<ItemStock> itemStockList)
        {
            decimal orderCost = default;

            foreach (ItemDto itemDto in ItemDtoList)
            {
                ItemStock itemStock = itemStockList.First(x => x.Id == itemDto.Id);
                orderCost += itemDto.Quantity * itemStock.Cost;
            }

            return orderCost;
        }

        private void AddItemsToList(List<ItemDto> itemDtoList, List<ItemStock> itemStockList, IMapper mapper)
        {
            foreach (ItemDto itemDto in itemDtoList)
            {
                ItemStock itemStock = itemStockList.First(x => x.Id == itemDto.Id);

                ItemOrder itemOrder = new();
                mapper.Map(itemDto, itemOrder);
                itemOrder.Cost = itemStock.Cost;

                Items.Add(itemOrder);
            }
        }
    }
}