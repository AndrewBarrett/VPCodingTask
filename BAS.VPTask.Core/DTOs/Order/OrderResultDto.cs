using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.VPTask.Core.DTOs.Order
{
    public sealed class OrderResultDto
    {
        public OrderResultDto(bool successState)
        {
            Success = successState;
        }

        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new();
    }
}