using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.Common.Interfaces
{
    public interface IBusinessService <T> where T:IModel
    {
        Task<T> Find(T dto);
        Task<List<T>> GetMany(int start, int skip, int max);
        Task<T> Create(T dto);
        Task<T> Remove(T dto);
        Task<T> Update(T dto);
        void Dispose();
    }
}
