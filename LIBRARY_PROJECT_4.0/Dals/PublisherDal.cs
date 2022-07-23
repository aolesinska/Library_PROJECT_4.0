using LIBRARY_PROJECT_4._0.DalModels.PublisherModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    /// <summary>
    /// Publishers' data source connection
    /// </summary>
    internal class PublisherDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();

        /// <summary>
        /// Returns publishers' information used for filling the table
        /// </summary>
        public IList<PublisherDalModel> getPublisherList =>
            db.Publishers.Select(
                publisher => new PublisherDalModel
                {
                    Name = publisher.Name,
                    City = publisher.City,
                    Street = publisher.Street,
                    BuildingNum = publisher.BuildingNum,
                    Postcode = publisher.Postcode,
                }).ToList();

        /// <summary>
        /// Returns publishers' information needed for the combobox
        /// </summary>
        public IList<PublisherDalModelForSelector> getPublisherForSelectorList =>
            db.Publishers.Select(
                publisher => new PublisherDalModelForSelector
                {
                    ID = publisher.ID,
                    Name = publisher.Name,
                }).ToList();

        /// <summary>
        /// Function which adds new publisher to the Database
        /// </summary>
        /// <param name="name">Publisher's name</param>
        /// <param name="city">Publisher's city</param>
        /// <param name="street">Publisher's street</param>
        /// <param name="num">Publisher's building number</param>
        /// <param name="post">Publisher's postcode</param>
        internal void Add(string name, string city, string street, string num, string post)
        {
            var newPublisher = new Publisher()
            {
                Name = name,
                City = city,
                Street = street,
                BuildingNum = num,
                Postcode = post
            };

            db.Publishers.Add(newPublisher);
            db.SaveChanges();
        }

        /// <summary>
        /// Function which updates publisher's information in the Database
        /// </summary>
        /// <param name="name">Publisher's old name</param>
        /// <param name="nameUpdate">Publisher's new name</param>
        /// <param name="city">Publisher's city</param>
        /// <param name="street">Publisher's street</param>
        /// <param name="num">Publisher's building number</param>
        /// <param name="post">Publisher's postcode</param>
        internal void Update(string name, string nameUpdate, string city, string street, string num, string post)
        {
            var publisherToUpdate = db.Publishers
                .Where(pub => pub.Name == name)
                .Select(pub => pub)
                .Single();

            if (publisherToUpdate != null)
            {
                publisherToUpdate.Name = nameUpdate;
                publisherToUpdate.City = city;
                publisherToUpdate.Street = street;
                publisherToUpdate.BuildingNum = num;
                publisherToUpdate.Postcode = post;
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Function which deletes publisher from the Database
        /// </summary>
        /// <param name="name">Publisher's name</param>
        internal void Delete(string name)
        {
            var publisherToDelete =
                db.Publishers
                .Where(pub => pub.Name == name)
                .Select(pub => pub)
                .Single();
            db.Books
                .Where(book => book.PublisherID == publisherToDelete.ID)
                .ToList()
                .ForEach(x =>
                {
                    x.PublisherID = null;
                });

            db.Publishers.Remove(publisherToDelete);
            db.SaveChanges();
        }
    }
}
