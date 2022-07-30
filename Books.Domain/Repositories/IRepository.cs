using TestBooks.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBooks.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity :class
    {
        Task<TaskResult<TEntity>> AddAsync(TEntity entity);
        Task<TaskResult<IEnumerable<TEntity>>> GetAsync();
        Task<TaskResult<TEntity>> GetAsync(int id);
        Task<TaskResult<TEntity>> UpdateAsync(int id, TEntity entity);
        Task<TaskResult<TEntity>> DeleteAsync(int id);
    }

}
