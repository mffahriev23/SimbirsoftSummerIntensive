using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirsoftSummerIntensive.Infrastructure.DB.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        public Task<T> Get(long Id);
        public Task Delete(long Id);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task AddRange(IEnumerable<T> entities);
    }
}
