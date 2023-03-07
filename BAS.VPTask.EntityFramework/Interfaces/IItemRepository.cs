using BAS.VPTask.Core.Entities;

namespace BAS.VPTask.EntityFramework.Interfaces
{
    public interface IItemRepository
    {
        Task<List<ItemStock>> FetchItemListByIdAsync(List<Guid> itemIdList);
    }
}
