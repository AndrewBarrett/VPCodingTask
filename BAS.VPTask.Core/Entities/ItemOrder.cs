namespace BAS.VPTask.Core.Entities
{
    public sealed class ItemOrder
    {
        public Guid Id { get; set; }
        public ItemStock ItemStock { get; set; } = new();
        public Guid ItemStockId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}