using BooksInventory.Data;
using BooksInventory.Models;
using BooksInventory.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksInventory.Controllers
{
    //[Route("api/Books")]
    //[ApiController]
    public class BooksController : Controller
    {
        private readonly AppDbContext _appDb;//Call AppDbContext

        //create a constructor
        public BooksController(AppDbContext _Db)
        {
            _appDb = _Db;
        }

        public async Task<IActionResult> Index()
        {

            BooksViewModel ViewBooks = new()
            {
                BookDetails = _appDb.BookTypes,
                BookName = "Kasahorow Books"
            };

            //Get BookType Data into a list
            //ViewBag.Data  = _appDb.BookTypes.ToList();
            //IEnumerable<BookType> bookTypes = _appDb.BookTypes;
            //return View(bookTypes);
            return View(ViewBooks);
        }

        //Go to CreatBook Page
        public IActionResult CreateBook(int? id)
        {
            if (id > 0)
            {
                var getBookDetails = _appDb.BookTypes.Find(id);
                return getBookDetails != null ? View(getBookDetails) : NotFound();
            }
            return View();
        }

        //Create New Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(BookType bookTypeValues)
        {
            if (ModelState.IsValid)//Check if values entered in input fields are valid
            {
                //Custom Error
                //if (bookTypeValues.ISBN.Length < 3)
                //{
                //    ModelState.AddModelError("ISBN", "ISBN must be longer than 3 characters");
                //    return View();
                //}
                await _appDb.BookTypes.AddAsync(bookTypeValues);//Add book values to DB
                await _appDb.SaveChangesAsync();//Save changes to DB
                //return CreateBook();//Redirect To Books View Index Page
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBook(BookType bookTypeValues)
        {
            _appDb.BookTypes.Update(bookTypeValues);
            await _appDb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBook(int? id)
        {
            if(id != null)
            {
                BookType? getBook = _appDb.BookTypes.Find(id);
                _appDb.BookTypes.Remove(getBook);
                await _appDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return NotFound();
        }

        #region ***** API Methods ****
        [HttpGet]
        public IActionResult GetBooks()
        {
            var JsonData = Json(new { data =_appDb.BookTypes.ToList() });
            return JsonData;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id != null)
            {
                BookType? getBook = _appDb.BookTypes.Find(id);
                if(getBook != null)
                {
                    _appDb.BookTypes.Remove(getBook);
                    await _appDb.SaveChangesAsync();
                    return Json(new { success = true, message = "Book Deleted" });
                }
                else
                    return Json(new { success = false, message = "couldnot delete book. Try again." });

            }
            return Json(new { success = false, message = "couldnot delete book. Try again." });
        }
        #endregion
    }
}
