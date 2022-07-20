using LIBRARY_PROJECT_4._0.DalModels.AutorModels;
using LIBRARY_PROJECT_4._0.Dals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LIBRARY_PROJECT_4._0
{
    /// <summary>
    /// Interaction logic for AutorWindow.xaml
    /// </summary>
    public partial class AutorWindow : Window
    {
        AutorDal autorDal = new AutorDal();

        public AutorWindow()
        {
            InitializeComponent();
            LoadAutorData();
        }

        private void LoadAutorData() => this.gridAutors.ItemsSource = autorDal.getAuthorNameList;

        private void BtnBackToNav_Click(object sender, RoutedEventArgs e) => this.Close();
        private void clearInput()
        {
            this.AutorFirstN.Text = "";
            this.AutorLastN.Text = "";
            this.AutorFirstN_Update.Text = "";
            this.AutorLastN_Update.Text = "";
        }

        private void BtnAddAutor_Click(object sender, RoutedEventArgs e)
        {
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
            clearInput();
        }

        private void BtnDeleteAutor_Click(object sender, RoutedEventArgs e)
        {
            autorDal.Delete(AutorLastN_Update.Text);
            clearInput();
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
            clearInput();
        }
    }
}
