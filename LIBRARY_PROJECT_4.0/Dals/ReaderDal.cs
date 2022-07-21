using LIBRARY_PROJECT_4._0.DalModels.ReaderModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    /// <summary>
    /// 
    /// </summary>
    internal class ReaderDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="pesel"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
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
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="pesel"></param>
        /// <param name="emailUpdate"></param>
        /// <param name="phone"></param>
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
        /// 
        /// </summary>
        /// <param name="email"></param>
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
