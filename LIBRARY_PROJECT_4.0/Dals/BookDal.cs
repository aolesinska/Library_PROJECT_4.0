using LIBRARY_PROJECT_4._0.DalModels.BookModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    internal class BookDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();

        public List<BookDalModel> getBooksList =>
            db.Books.Select(
                book => new BookDalModel
                {
                    Title = book.Title,
                    ISBN = book.ISBN,
                    Category = book.Category.Categorie,
                    Autor = book.Autor.FirstName + " " + book.Autor.LastName,
                    Publisher = book.Publisher.Name,
                    Status = book.Status.Status1,
                }).ToList();
        public void Add(string title, string isbn, int categoryID, int authorId, int publisherID, int statusId)
        {
            var newBook = new Book()
            {
                Title = title,
                ISBN = isbn,
                CategorieID = categoryID,
                AutorID = authorId,
                PublisherID = publisherID,
                StatusID = statusId,
            };

            db.Books.Add(newBook);
            db.SaveChanges();
        }
        public void Delete(string title)
        {
            var bookToDelete = db.Books
                .Where(book => book.Title == title)
                .Select(book => book)
                .FirstOrDefault();

            db.Books.Remove(bookToDelete);
            db.SaveChanges();
        }
    }
}
