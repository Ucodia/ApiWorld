using ApiWorld.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ApiWorld.Win8
{
    public sealed partial class MainPage : Page
    {
        private ApisService _apiService;
        private int _offset = 0;
        private const int Limit = 20;

        public MainPage()
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
                var result = await _apiService.GetApis(limit: Limit, offset: _offset);

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

                var dialog = new MessageDialog(message);
                dialog.ShowAsync();
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
