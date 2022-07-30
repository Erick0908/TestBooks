using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBooks.Domain.Entities;

namespace TestBooks.Domain.Repositories
{
 public interface IBooksRepository: IRepository<TestBooks.Domain.Entities.Books>
    {

    }
}
