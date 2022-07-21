using LIBRARY_PROJECT_4._0.DalModels.PublisherModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    internal class PublisherDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();
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
        public IList<PublisherDalModelForSelector> getPublisherForSelectorList =>
            db.Publishers.Select(
                publisher => new PublisherDalModelForSelector
                {
                    ID = publisher.ID,
                    Name = publisher.Name,
                }).ToList();

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
