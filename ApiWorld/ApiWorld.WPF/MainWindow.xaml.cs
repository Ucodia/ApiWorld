using ApiWorld.Model;
using System;
using System.Windows;

namespace ApiWorld.WPF
{
    public partial class MainWindow : Window
    {
        private ApisService _apiService;
        private int _offset = 0;
        private const int Limit = 20;

        public MainWindow()
        {
            InitializeComponent();

            _apiService = new ApisService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Disable button
            LoadButton.IsEnabled = false;
            LoadButton.Content = "Loading...";

            try
            {
                // Call API service
                var result = await _apiService.GetApis(limit:Limit, offset:_offset);

                // Load items in list
                foreach (var api in result.Apis)
                {
                    ApiListBox.Items.Add(api);
                }

                // Update offset
                _offset += Limit;
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
                // Reenable button
                LoadButton.IsEnabled = true;
                LoadButton.Content = string.Format("Load {0} more items", Limit);
            }
        }
    }
}
