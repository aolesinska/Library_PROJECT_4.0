using LIBRARY_PROJECT_4._0.DalModels.ReaderModels;
using LIBRARY_PROJECT_4._0.Dals;
using LIBRARY_PROJECT_4._0.ValidationRules;
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
    /// Interaction logic for ReaderWindow.xaml
    /// </summary>
    public partial class ReaderWindow : Window
    {
        ReaderDal readerDal = new ReaderDal();
        ReaderValidation readerValidation = new ReaderValidation();

        public ReaderWindow()
        {
            InitializeComponent();
            LoadReaderData();
        }
        private void LoadReaderData() => this.gridReaders.ItemsSource = readerDal.getReaderList;
        private void clearInput()
        {
            this.r_fname.Text = "";
            this.r_lname.Text = "";
            this.r_pesel.Text = "";
            this.r_email.Text = "";
            this.r_phone.Text = "";
        }
        protected string readerEmail;
        private void gridReaders_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridReaders.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridReaders.SelectedItems.Count >= 0)
                    {
                        var reader = (ReaderDalModel)this.gridReaders.SelectedItems[0];

                        readerEmail = reader.Email;

                        this.r_fname.Text = reader.FirstName;
                        this.r_lname.Text = reader.LastName;
                        this.r_pesel.Text = reader.PESEL;
                        this.r_email.Text = reader.Email;
                        this.r_phone.Text = reader.Phone;
                    }
                }
                catch (InvalidCastException) { }
            }
        }

        private void BtnBackToNav_Click(object sender, RoutedEventArgs e) => this.Close();

        private void BtnAddReader_Click(object sender, RoutedEventArgs e)
        {
            var result = readerValidation.Validation(r_fname.Text, r_lname.Text, r_email.Text,r_pesel.Text);
            if (!result.IsValidate)
            {
                MessageBox.Show(result.ErrorMsg);
                return;
            }

            try
            {
                if (r_fname.Text.Length == 0 || r_lname.Text.Length == 0)
                    throw new Exception("Fields can not be empty");

                readerDal.Add(
                    r_fname.Text,
                    r_lname.Text,
                    r_pesel.Text,
                    r_email.Text,
                    r_phone.Text
                    );
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.Message}");
            }

            LoadReaderData();
            clearInput();
        }

        private void BtnUpdateReader_Click(object sender, RoutedEventArgs e)
        {
            var result = readerValidation.Validation(r_fname.Text, r_lname.Text, r_email.Text, r_pesel.Text);
            if (!result.IsValidate)
            {
                MessageBox.Show(result.ErrorMsg);
                return;
            }

            try
            {
                if (r_fname.Text.Length == 0 || r_lname.Text.Length == 0)
                    throw new Exception("Fields can not be empty");

                string newfname = r_fname.Text;
                string newlname = r_lname.Text;
                string newpesel = r_pesel.Text;
                string newemail = r_email.Text;
                string newphone = r_phone.Text;

                readerDal.Update(readerEmail, newfname, newlname, newpesel, newemail, newphone);
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: { err.Message}");
            }

            LoadReaderData();
            clearInput();
        }

        private void BtnDeleteReader_Click(object sender, RoutedEventArgs e)
        {
            readerDal.Delete(readerEmail);
            LoadReaderData();
        }
    }
}
