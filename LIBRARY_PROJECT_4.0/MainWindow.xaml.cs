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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LIBRARY_PROJECT_4._0
{
    /// <summary>
    /// This class is used as navigation window. It includes events that open a specific windows.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBooks_Click(object sender, RoutedEventArgs e) => new BookWindow().Show();

        private void BtnAuthors_Click(object sender, RoutedEventArgs e) => new AutorWindow().Show();

        private void BtnPublishers_Click(object sender, RoutedEventArgs e) => new PublisherWindow().Show();

        private void BtnReaders_Click(object sender, RoutedEventArgs e) => new ReaderWindow().Show();
    }
}
