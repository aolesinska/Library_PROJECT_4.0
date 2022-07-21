using LIBRARY_PROJECT_4._0.DalModels.CategoryModels;
using LIBRARY_PROJECT_4._0.LibraryModels;
using System.Collections.Generic;
using System.Linq;

namespace LIBRARY_PROJECT_4._0.Dals
{
    /// <summary>
    /// Categories' data source connection
    /// </summary>
    internal class CategoryDal
    {
        private LibraryDB3Entities db = new LibraryDB3Entities();

        /// <summary>
        /// Returns categories' information needed for the combobox
        /// </summary>
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
