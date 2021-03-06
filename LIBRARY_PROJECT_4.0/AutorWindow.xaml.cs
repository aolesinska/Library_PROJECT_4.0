using LIBRARY_PROJECT_4._0.DalModels.AutorModels;
using LIBRARY_PROJECT_4._0.Dals;
using LIBRARY_PROJECT_4._0.ValidationRules;
using System;
using System.Windows;

namespace LIBRARY_PROJECT_4._0
{
    /// <summary>
    /// This class includes all functionality to manipulate author data
    /// </summary>
    public partial class AutorWindow : Window
    {
        AutorDal autorDal = new AutorDal();
        AuthorValidation authorValidation = new AuthorValidation();

        public AutorWindow()
        {
            InitializeComponent();
            LoadAutorData();
        }

        private void LoadAutorData() => this.gridAutors.ItemsSource = autorDal.getAuthorNameList;

        private void BtnBackToNav_Click(object sender, RoutedEventArgs e) => this.Close();
        private void ClearInput()
        {
            this.AutorFirstN.Text = "";
            this.AutorLastN.Text = "";
            this.AutorFirstN_Update.Text = "";
            this.AutorLastN_Update.Text = "";
        }

        private void BtnAddAutor_Click(object sender, RoutedEventArgs e)
        {
            var result = authorValidation.Validation(AutorFirstN.Text, AutorLastN.Text);
            if (!result.IsValidate)
            {
                MessageBox.Show(result.ErrorMsg);
                return;
            }

            try
            {
                if (AutorFirstN.Text.Length == 0 || AutorLastN.Text.Length == 0)
                    throw new Exception("Fields can not be empty");

                autorDal.Add(
                    AutorFirstN.Text,
                    AutorLastN.Text
                    );
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.Message}");
            }

            LoadAutorData();
            ClearInput();
        }

        private void BtnDeleteAutor_Click(object sender, RoutedEventArgs e)
        {
            autorDal.Delete(AutorLastN_Update.Text);
            ClearInput();
            LoadAutorData();

        }
        protected string autorLastNameUpdate;
        private void gridAuthors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridAutors.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridAutors.SelectedItems.Count >= 0)
                    {
                        var autor = (AutorDalModel)this.gridAutors.SelectedItems[0];

                        autorLastNameUpdate = autor.LastName;

                        this.AutorFirstN_Update.Text = autor.FirstName;
                        this.AutorLastN_Update.Text = autor.LastName;

                    }
                }
                catch (InvalidCastException) { }
            }
        }
        private void BtnUpdateAutor_Click(object sender, RoutedEventArgs e)
        {
            var result = authorValidation.Validation(AutorFirstN.Text, AutorLastN.Text);
            if (!result.IsValidate)
            {
                MessageBox.Show(result.ErrorMsg);
                return;
            }

            try
            {
                if (AutorFirstN_Update.Text.Length == 0 || AutorLastN_Update.Text.Length == 0)
                    throw new Exception("Fields can not be empty");

                string newFName = AutorFirstN_Update.Text;
                string newLName = AutorLastN_Update.Text;


                autorDal.Update(autorLastNameUpdate, newFName, newLName);
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: { err.Message}");
            }

            LoadAutorData();
            ClearInput();
        }

        private void BtnClearInput_Click(object sender, RoutedEventArgs e)
        {
            ClearInput();
        }
    }
}
