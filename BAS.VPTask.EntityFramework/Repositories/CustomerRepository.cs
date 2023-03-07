using AutoMapper;
using BAS.VPTask.Core.DTOs.Item;
using BAS.VPTask.Core.DTOs.Order;
using BAS.VPTask.Core.Entities;
using BAS.VPTask.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BAS.VPTask.EntityFramework.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VPTaskDbContext _context;
        private readonly DbSet<Customer> _dbSet;
        private readonly DbSet<ItemStock> _dbSetItemStock;
        private readonly IMapper _mapper;

        public CustomerRepository(VPTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
            _dbSetItemStock = context.Set<ItemStock>();
            _mapper = mapper;
        }

        public async Task CreateGuestOrderAsync(OrderDto orderDto)
        {
            Customer customer = new();
            _mapper.Map(orderDto.CustomerDto, customer);

            List<Guid> itemIdList = orderDto.ItemDtoList.Select(x => x.Id).ToList();
            List<ItemStock> itemStockList = await _dbSetItemStock.Where(x => itemIdList.Contains(x.Id)).AsNoTracking().ToListAsync();

            Order order = new(orderDto.ItemDtoList, itemStockList, _mapper);
            customer.Orders.Add(order);

            _dbSet.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}