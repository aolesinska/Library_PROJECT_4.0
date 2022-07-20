using LIBRARY_PROJECT_4._0.DalModels.AutorModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_4._0.Dals
{
    internal class AutorDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();

        public IList<AutorDalModel> getAuthorNameList =>
            db.Autors.Select(
                author => new AutorDalModel
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                }).ToList();

        public IList<AutorDalModelForSelector> getAuthorList =>
            db.Autors.Select(
                author => new AutorDalModelForSelector
                {
                    ID = author.ID,
                    Name = author.FirstName + " " + author.LastName
                }).ToList();
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
