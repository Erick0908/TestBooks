using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBooks.Client.Models;

namespace TestBooks.Client.Services
{
    public interface IBooksService
    {
        Task<TaskResult<Books>> AddAsync(Books entity);
        Task<TaskResult<IEnumerable<Books>>> GetAsync();
        Task<TaskResult<Books>> GetAsync(int id);
        Task<TaskResult<Books>> UpdateAsync(int id, Books entity);
        Task<TaskResult<Books>> DeleteAsync(int id);
    }
}
