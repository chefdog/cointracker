using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.Common.Interfaces
{
    public interface IRepository : IDisposable
    {
        IQueryable<IModel> GetMany(Int32 pageSize, Int32 pageNumber, object queryParam);

        Task<IModel> GetAsync(IModel entity);

        Task<IModel> GetByIdAsync(Int64 id);

        Task<IModel> AddAsync(IModel entity);

        Task<List<IModel>> AddRangeAsync(List<IModel> data);

        Task<IModel> UpdateAsync(IModel changes);

        Task<IModel> DeleteAsync(IModel changes);
    }
}
