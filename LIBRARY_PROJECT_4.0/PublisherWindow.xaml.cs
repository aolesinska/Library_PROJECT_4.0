using LIBRARY_PROJECT_4._0.DalModels.PublisherModels;
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
    /// This class includes all functionality to manipulate publisher data
    /// </summary>
    public partial class PublisherWindow : Window
    {
        PublisherDal publisherDal = new PublisherDal();
        PublisherValidation publisherValidation = new PublisherValidation();

        public PublisherWindow()
        {
            InitializeComponent();
            LoadPublisherData();
        }

        private void LoadPublisherData() => this.gridPublishers.ItemsSource = publisherDal.getPublisherList;

        private void BtnBackToNav_Click(object sender, RoutedEventArgs e) => this.Close();
        private void ClearInput()
        {
            this.pub_name.Text = "";
            this.pub_city.Text = "";
            this.pub_street.Text = "";
            this.pub_num.Text = "";
            this.pub_post.Text = "";
        }
        private void BtnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            var result = publisherValidation.Validation(pub_post.Text);
            if (!result.IsValidate)
            {
                MessageBox.Show(result.ErrorMsg);
                return;
            }

            try
            {
                if (pub_name.Text.Length == 0)
                    throw new Exception("Field 'Name' can not be empty");

                publisherDal.Add(
                    pub_name.Text,
                    pub_city.Text,
                    pub_street.Text,
                    pub_num.Text,
                    pub_post.Text
                    );
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.Message}");
            }

            LoadPublisherData();
            ClearInput();
        }
        protected string publisherName;
        private void gridPublishers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.gridPublishers.SelectedIndex >= 0)
            {
                try
                {
                    if (this.gridPublishers.SelectedItems.Count >= 0)
                    {
                        var publisher = (PublisherDalModel)this.gridPublishers.SelectedItems[0];

                        publisherName = publisher.Name;

                        this.pub_name.Text = publisher.Name;
                        this.pub_city.Text = publisher.City;
                        this.pub_street.Text = publisher.Street;
                        this.pub_num.Text = publisher.BuildingNum;
                        this.pub_post.Text = publisher.Postcode;
                    }
                }
                catch (InvalidCastException) { }
            }
        }
        private void BtnUpdatePublisher_Click(object sender, RoutedEventArgs e)
        {
            var result = publisherValidation.Validation(pub_post.Text);
            if (!result.IsValidate)
            {
                MessageBox.Show(result.ErrorMsg);
                return;
            }

            try
            {
                if (pub_name.Text.Length == 0)
                    throw new Exception("Field 'Name' can not be empty");

                string newName = pub_name.Text;
                string newCity = pub_city.Text;
                string newStreet = pub_street.Text;
                string newNum = pub_num.Text;
                string newPost = pub_post.Text;

                publisherDal.Update(publisherName, newName, newCity, newStreet, newNum, newPost);
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: { err.Message}");
            }

            LoadPublisherData();
            ClearInput();
        }

        private void BtnDeletePublisher_Click(object sender, RoutedEventArgs e)
        {
            publisherDal.Delete(publisherName);
            LoadPublisherData();
        }

        private void BtnClearInput_Click(object sender, RoutedEventArgs e)
        {
            ClearInput();
        }
    }
}
