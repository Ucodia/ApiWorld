using ApiWorld.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        public MainPage()
        {
            InitializeComponent();

            _apiService = new ApisService();
        }

        public ObservableCollection<Api> Apis { get; set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = await _apiService.GetApis();

            ApiListBox.Items.Clear();

            foreach (var api in result.Apis)
            {
                ApiListBox.Items.Add(api);
            }
        }
    }
}
