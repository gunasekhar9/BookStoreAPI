using ModelLayer.Services.BookModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IBookRL
    {
        void addBook(BookModel bookModel);
        List<BookModel> GetAllBookModels();
        void updateBook(BookModel bookModel);
        void deleteBook(BookModel bookModel);
        BookModel GetBookModel(int? id);
    }
}
