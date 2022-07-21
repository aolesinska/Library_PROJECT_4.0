using System.Windows;

namespace LIBRARY_PROJECT_4._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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
