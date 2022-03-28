using BusinessLayer;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        [HttpPost]
        public ActionResult addBook(BookModel bookModel)
        {
            try
            {
                this.bookBL.addBook(bookModel);
                return this.Ok(new { success = true, message = $"Book added Successfully  {bookModel.BookName}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult GetAllBookModels()
        {
            try
            {
                List<BookModel> bookTables = new List<BookModel>();
                bookTables = this.bookBL.GetAllBookModels().ToList();
                if (bookTables != null)
                {
                    return this.Ok(new { success = true, message = $"Successs :- These are the AllBooks", response=bookTables});
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Get AllBooks Data is not Found"});
            }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet]
        public ActionResult GetBookModel(int? BookId)
        {
            try
            {
                if (BookId != null)
                {
                    var result = this.bookBL.GetBookModel(BookId);
                    return this.Ok(new { success = true, message = $"Successs :- This is the Book by That ID", response =result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Get Book Data by That ID is not Found" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [Authorize]
        [HttpPut]
        public ActionResult updateBook(BookModel bookModel)
        {
            try
            {
                this.bookBL.updateBook(bookModel);
                return this.Ok(new { success = true, message = $"Book updated Successfully  {bookModel.BookName}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [HttpDelete]
        public ActionResult deleteBook(int? BookId)
        {
            try
            {
                if (BookId != null)
                {
                    return this.BadRequest(new { success = false, message = "Enter the Book ID" });
                }
                var Book = this.bookBL.GetBookModel(BookId);
                if(Book !=null)
                {
                    this.bookBL.deleteBook(Book);
                    return this.Ok(new { success = true, message = $"Successs :- {Book.BookName} is Deleted"});
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"Fail :- {Book.BookName} is Not Deleted" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}