using Books.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBooks.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _booksService.GetAsync());
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _booksService.GetAsync(id));
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post(BooksDto books)
        {
          return Ok(await _booksService.AddAsync(books));
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BooksDto books)
        {
            return Ok(await _booksService.UpdateAsync(id, books));
        } 


        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _booksService.DeleteAsync(id));
        }
    }
}
