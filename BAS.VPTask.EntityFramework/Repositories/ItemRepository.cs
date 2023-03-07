using BAS.VPTask.Core.Entities;
using BAS.VPTask.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BAS.VPTask.EntityFramework.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DbSet<ItemStock> _dbSet;

        public ItemRepository(VPTaskDbContext context)
        {
            _dbSet = context.Set<ItemStock>();
        }

        public async Task<List<ItemStock>> FetchItemListByIdAsync(List<Guid> itemIdList)
        {
            return await _dbSet.Where(x => itemIdList.Contains(x.Id)).AsNoTracking().ToListAsync();
        }
    }
}