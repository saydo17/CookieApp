﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CookieApp.UI.ViewModels;
using CookieApp.UI.Views;

namespace CookieApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var shell = new ShellView();
            shell.DataContext = new ShellViewModel();
            shell.Show();
        }
    }
}
