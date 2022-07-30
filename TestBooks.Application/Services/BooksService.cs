using AutoMapper;
using Books.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBooks.Domain.Common;
using TestBooks.Domain.DTOs;
using TestBooks.Domain.Repositories;

namespace TestBooks.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository bookRepository, IMapper mapper)
        {
           _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<TaskResult<BooksDto>> AddAsync(BooksDto entity)
        {
           var book = _mapper.Map<TestBooks.Domain.Entities.Books>(entity);
           var response = await _bookRepository.AddAsync(book);

            var taskResult = new TaskResult<BooksDto>
            {
                Data = _mapper.Map<BooksDto>(response.Data)
            };


            if (response.Success)
            {
                taskResult.AddMessage(response.Message);
            }
            else
            {
                taskResult.AddErrorMessage(response.Message);

            }
            return taskResult;
        }

        public async Task<TaskResult<BooksDto>> DeleteAsync(int id)
        {
            var response = await _bookRepository.DeleteAsync(id);

            var taskResult = new TaskResult<BooksDto>
            {
                Data = _mapper.Map<BooksDto>(response.Data)
            };


            if (response.Success)
            {
                taskResult.AddMessage(response.Message);
            }
            else
            {
                taskResult.AddErrorMessage(response.Message);

            }
            return taskResult;


        }

        public async Task<TaskResult<IEnumerable<BooksDto>>> GetAsync()
        {

            var response = await _bookRepository.GetAsync();

            var taskResult = new TaskResult<IEnumerable<BooksDto>>
            {
                Data = _mapper.Map<IEnumerable<BooksDto>>(response.Data)
            };


            if (response.Success)
            {
                taskResult.AddMessage(response.Message);
            }
            else
            {
                taskResult.AddErrorMessage(response.Message);

            }
            return taskResult;
        }

        public async Task<TaskResult<BooksDto>> GetAsync(int id)
        {
            var response = await _bookRepository.GetAsync(id);

            var taskResult = new TaskResult<BooksDto>
            {
                Data = _mapper.Map<BooksDto>(response.Data)
            };


            if (response.Success)
            {
                taskResult.AddMessage(response.Message);
            }
            else
            {
                taskResult.AddErrorMessage(response.Message);

            }
            return taskResult;

        }

        public async Task<TaskResult<BooksDto>> UpdateAsync(int id, BooksDto entity)
        {

            var book = _mapper.Map<TestBooks.Domain.Entities.Books>(entity);
            var response = await _bookRepository.UpdateAsync(id,book);

            var taskResult = new TaskResult<BooksDto>
            {
                Data = _mapper.Map<BooksDto>(response.Data)
            };


            if (response.Success)
            {
                taskResult.AddMessage(response.Message);
            }
            else
            {
                taskResult.AddErrorMessage(response.Message);

            }
            return taskResult;
        }
    }
}
