using LIBRARY_PROJECT_4._0.DalModels.StatusModel;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    internal class StatusDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();
        public IList<StatusDalModelForSelector> getStatusList =>
            db.Status.Select
            (
                status => new StatusDalModelForSelector
                {
                    ID = status.ID,
                    Name = status.Status1,
                }).ToList();
    }
}
