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
using PersistentStorage;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private IStorage storage;

        public MainPage() 
        {
            InitializeComponent();
            storage = StorageFactory.CreateStorage();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Adding key " + Key.Text + " with value " + Value.Text);
            storage.Save(Key.Text, Value.Text);
        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                getTextBlock.Text = storage.Get(testKey.Text);
            }
            catch (Exception ex)
            {
                getTextBlock.Text = ex.Message;
            }
        }
    }
}
