namespace LIBRARY_PROJECT_4._0.DalModels.ReaderModels
{
    /// <summary>
    /// Model created to display reader in the table without ID property
    /// </summary>
    internal class ReaderDalModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
