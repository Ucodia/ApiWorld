using ApiWorld.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ApiWorld.WPF
{
    public partial class MainWindow : Window
    {
        private ApisService _apiService;


        public MainWindow()
        {
            InitializeComponent();

            _apiService = new ApisService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadButton.IsEnabled = false;
            LoadButton.Content = "Loading...";

            try
            {
                var result = await _apiService.GetApis();

                ApiListBox.Items.Clear();

                foreach (var api in result.Apis)
                {
                    ApiListBox.Items.Add(api);
                }
            }
            catch (Exception ex)
            {
                var message = string.Format(
                    "Oops, something went wrong. Here's the ugly details:\n{0}",
                    ex.Message);

                MessageBox.Show(message);
            }
            finally
            {
                LoadButton.IsEnabled = true;
                LoadButton.Content = "Load";
            }
        }
    }
}
