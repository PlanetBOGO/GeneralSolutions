using GeneralSolutions;
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
using System.Data.Entity;

namespace GeneralSolutons.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewDatabaseEntities db = new NewDatabaseEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = db.Items.Include(i => i.Category).ToList();
            grid1.ItemsSource = items;
            grid1.Columns.Remove(grid1.Columns.Last());
            grid1.Columns.RemoveAt(12);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CacheTextFileReaderModule cacheModule = new CacheTextFileReaderModule();
            cacheModule.Context.AbsoluteFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "cacheText.txt";
            cacheModule.Context.ExparationInSeconds = 30;

            String fileContent = cacheModule.Read();

            if (cacheModule.Status == CacheTextFileReaderStatus.FileFromCache)
                MessageBox.Show("Read from cache");

            MessageBox.Show(fileContent);
        }
    }
}
