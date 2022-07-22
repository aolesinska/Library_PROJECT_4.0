using LIBRARY_PROJECT_4._0.DalModels.BookModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    internal class BookDal
    {
        /// <summary>
        /// Books' data source connection
        /// </summary>
        private LibraryDB3Entities db = new LibraryDB3Entities();

        /// <summary>
        /// Returns books' information used for filling the table
        /// </summary>
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

        /// <summary>
        /// Function which adds new book to the Database
        /// </summary>
        /// <param name="title">Book's title</param>
        /// <param name="isbn">Book's ISBN number</param>
        /// <param name="categoryID">Book's category identified by ID</param>
        /// <param name="authorId">Book's author identified by ID</param>
        /// <param name="publisherID">Book's publisher identified by ID</param>
        /// <param name="statusId">Book's status identified by ID</param>
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

        /// <summary>
        /// Function which deletes book from the Database based on title
        /// </summary>
        /// <param name="title">Book's title</param>
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
