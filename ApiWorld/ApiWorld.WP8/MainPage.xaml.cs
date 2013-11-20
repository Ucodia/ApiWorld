using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ApiWorld.WP8.Resources;
using ApiWorld.Model;
using System.Collections.ObjectModel;

namespace ApiWorld.WP8
{
    public partial class MainPage : PhoneApplicationPage
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