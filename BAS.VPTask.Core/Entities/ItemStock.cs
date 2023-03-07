namespace BAS.VPTask.Core.Entities
{
    public sealed class ItemStock
    {
        public Guid Id { get; set; }
        public int CurrentStock { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
    }
}