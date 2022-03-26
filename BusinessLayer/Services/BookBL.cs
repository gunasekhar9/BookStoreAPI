using ModelLayer.Services.BookModel;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBL: IBookBL
    {
        IBookRL bookRL;

        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public void addBook(BookModel bookModel)
        {
            try
            {
                this.bookRL.addBook(bookModel);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<BookModel> GetAllBookModels()
        {
            try
            {
               return this.bookRL.GetAllBookModels();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public BookModel GetBookModel(int? id)
        {
            try
            {
                return this.bookRL.GetBookModel(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void deleteBook(BookModel bookModel)
        {
            try
            {
                this.bookRL.deleteBook(bookModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void updateBook(BookModel bookModel)
        {
            try
            {
                bookRL.updateBook(bookModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}