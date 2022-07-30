using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBooks.Client.Models;
using TestBooks.Client.Services;

namespace TestBooks.Client.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        // GET: BooksController
        public async Task<ActionResult> Index()
        {
            var model = await _booksService.GetAsync();
            return View(model);
        }

        // GET: BooksController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _booksService.GetAsync(id);
            return View(model);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            
            return View(new Books());
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Books book)
        {

            if (!ModelState.IsValid)
            {
                return View();
;            }

            var model = await _booksService.AddAsync(book);
            if(model.Success)
            {

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
