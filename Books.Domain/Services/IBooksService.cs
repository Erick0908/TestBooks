using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBooks.Domain.DTOs;
using TestBooks.Domain.Services;

namespace Books.Domain.Services
{
    public interface IBooksService : IService<BooksDto>
    {

    }
}
