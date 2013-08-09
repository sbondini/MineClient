﻿using System.Windows;
using WpfClient.Model;
using WpfClient.Model.Concrete;
using WpfClient.Services;
using WpfClient.ViewModel;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();

            IocService.SetBindings();
            DataContext = IoC.Resolve<MainVm>();
        }
    }
}
