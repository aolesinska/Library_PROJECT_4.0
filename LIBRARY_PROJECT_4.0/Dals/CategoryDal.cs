using LIBRARY_PROJECT_4._0.DalModels.CategoryModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    internal class CategoryDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();
        public IList<CategoryDalModelForSelector> getCategoryList =>
            db.Categories.Select
            (
                category => new CategoryDalModelForSelector
                {
                    ID = category.ID,
                    Name = category.Categorie,
                }).ToList();

    }
}
