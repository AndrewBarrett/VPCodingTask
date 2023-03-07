﻿namespace BAS.VPTask.Core.Entities
{
    public sealed class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new();
    }
}