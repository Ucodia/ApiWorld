﻿using ApiWorld.Model;
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

            DataContext = this;

            _apiService = new ApisService();
            Apis = new ObservableCollection<Api>();
        }

        public ObservableCollection<Api> Apis { get; set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var apis = await _apiService.GetApis();

            Apis.Clear();

            foreach (var api in apis)
            {
                Apis.Add(api);
            }
        }
    }
}
