using LIBRARY_PROJECT_4._0.DalModels.AutorModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    /// <summary>
    /// Authors' data source connection
    /// </summary>
    internal class AutorDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();

        /// <summary>
        /// Returns authors' information needed for filling the table
        /// </summary>
        public IList<AutorDalModel> getAuthorNameList =>
            db.Autors.Select(
                author => new AutorDalModel
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                }).ToList();

        /// <summary>
        /// Returns authors' information needed for the combobox
        /// </summary>
        public IList<AutorDalModelForSelector> getAuthorList =>
            db.Autors.Select(
                author => new AutorDalModelForSelector
                {
                    ID = author.ID,
                    Name = author.FirstName + " " + author.LastName
                }).ToList();

        /// <summary>
        /// Function which adds new author to the Database
        /// </summary>
        /// <param name="firstName">Author's first name</param>
        /// <param name="lastName">Author's last name</param>
        public void Add(string firstName, string lastName)
        {
            var newAutor = new Autor()
            {
                FirstName = firstName,
                LastName = lastName
            };

            db.Autors.Add(newAutor);
            db.SaveChanges();
        }

        /// <summary>
        /// Function which deletes author from the Database based on last name
        /// </summary>
        /// <param name="lastName">Author's last name</param>
        public void Delete(string lastName)
        {
            var autorToDelete =
                db.Autors
                .Where(aut => aut.LastName == lastName)
                .Select(aut => aut)
                .Single();
            db.Books
               .Where(book => book.AutorID == autorToDelete.ID)
               .ToList()
               .ForEach(x =>
               {
                   x.AutorID = null;
               });

            db.Autors.Remove(autorToDelete);
            db.SaveChanges();
        }

        /// <summary>
        /// Function used to update authors' information in the Database based on previous last name
        /// </summary>
        /// <param name="lname">Author's last name</param>
        /// <param name="lnameUpdate">Author's new last name</param>
        /// <param name="fname">Author's new first name</param>
        internal void Update(string lname, string lnameUpdate, string fname)
        {
            var authorToUpdate = db.Autors
                .Where(aut => aut.LastName == lname)
                .Select(pub => pub)
                .Single();

            if (authorToUpdate != null)
            {
                authorToUpdate.FirstName = fname;
                authorToUpdate.LastName = lnameUpdate;
            }
            db.SaveChanges();
        }
    }
}
