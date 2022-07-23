using LIBRARY_PROJECT_4._0.DalModels.ReaderModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    /// <summary>
    /// Readers' data source connection
    /// </summary>
    internal class ReaderDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();

        /// <summary>
        /// Returns readers' information used for filling the table
        /// </summary>
        public IList<ReaderDalModel> getReaderList =>
            db.Readers.Select(
                reader => new ReaderDalModel
                {
                    FirstName = reader.FirstName,
                    LastName = reader.LastName,
                    PESEL = reader.PESEL,
                    Email = reader.Email,
                    Phone = reader.Phone,
                }).ToList();

        /// <summary>
        /// Function which adds new reader to the database
        /// </summary>
        /// <param name="firstname">Reader's first name</param>
        /// <param name="lastname">Reader's last name</param>
        /// <param name="pesel">Reader's PESEL</param>
        /// <param name="email">Reader's email</param>
        /// <param name="phone"> Reader's phone number</param>
        internal void Add(string firstname, string lastname, string pesel, string email, string phone)
        {
            var newReader = new Reader()
            {
                FirstName = firstname,
                LastName = lastname,
                PESEL = pesel,
                Email = email,
                Phone = phone
            };

            db.Readers.Add(newReader);
            db.SaveChanges();
        }

        /// <summary>
        /// Function which updates reader's information to the database
        /// </summary>
        /// <param name="email">Reader's old email</param>
        /// <param name="firstname">Reader's first name</param>
        /// <param name="lastname">Reader's last name</param>
        /// <param name="pesel">Reader's PESEL</param>
        /// <param name="emailUpdate">Reader's new email</param>
        /// <param name="phone">Reader's phone number</param>
        internal void Update(string email, string firstname, string lastname, string pesel, string emailUpdate, string phone)
        {
            var readerToUpdate = db.Readers
                .Where(read => read.Email == email)
                .Select(read => read)
                .Single();

            if (readerToUpdate != null)
            {
                readerToUpdate.FirstName = firstname;
                readerToUpdate.LastName = lastname;
                readerToUpdate.PESEL = pesel;
                readerToUpdate.Email = emailUpdate;
                readerToUpdate.Phone = phone;
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Function which deletes reader's information from the database
        /// </summary>
        /// <param name="email">Reader's email</param>
        internal void Delete(string email)
        {
            var readerToDelete =
                db.Readers
                .Where(pub => pub.Email == email)
                .Select(pub => pub)
                .Single();

            db.Readers.Remove(readerToDelete);
            db.SaveChanges();
        }
    }
}
