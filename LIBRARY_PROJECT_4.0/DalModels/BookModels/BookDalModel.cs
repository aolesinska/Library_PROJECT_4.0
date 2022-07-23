namespace LIBRARY_PROJECT_4._0.DalModels.BookModels
{
    /// <summary>
    /// Model created to display book in the table without ID property
    /// </summary>
    internal class BookDalModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public string Status { get; set; }
    }
}
