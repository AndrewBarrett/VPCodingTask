﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAS.VPTask.Core.DTOs.Order;

namespace BAS.VPTask.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResultDto> CreateGuestOrderAsync(OrderDto orderDto);
    }
}