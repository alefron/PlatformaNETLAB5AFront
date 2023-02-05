using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB5AFront.Data;
using LAB5AFront.Models;
using LAB5AFront.ViewModels;

namespace LAB5AFront.Controllers
{
    public class BookController : Controller
    {
        private readonly BooksDbContext _context;

        public BookController(BooksDbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            var books = await _context.Book.Include(b => b.Authors).ToListAsync();
            return View(books);
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var bookModel = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            var createModel = new CreateEditBookModel();
            createModel.AllAuthors = _context.Author.ToList();
            createModel.Book = new Book();
            return View(createModel);
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book", "AuthorId")] CreateEditBookModel bookModel)
        {
            //var number = Request.Form["authorSelect"];
            if (bookModel.Book != null)
            {
                var author = await _context.Author.Where(a => a.Id == bookModel.AuthorId).FirstOrDefaultAsync();
                bookModel.Book.Authors = new List<Author>();
                bookModel.Book.Authors.Add(author);
                _context.Book.Add(bookModel.Book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var bookModel = await _context.Book.FindAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }
            return View(bookModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,BookGenre,pagesCount,ReleaseDate")] Book bookModel)
        {
            if (id != bookModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookModelExists(bookModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookModel);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var bookModel = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'BooksDbContext.Movie'  is null.");
            }
            var bookModel = await _context.Book.FindAsync(id);
            if (bookModel != null)
            {
                _context.Book.Remove(bookModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookModelExists(int id)
        {
          return _context.Book.Any(e => e.Id == id);
        }
    }
}
