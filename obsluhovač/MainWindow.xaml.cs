﻿using System;
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

namespace obsluhovač
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Surovina_click(object sender, MouseButtonEventArgs e)
        {
            Image sur = new Image()
            {
                Source = new BitmapImage(new Uri("img/suroviny-" + (sender as Label).Name + ".png", UriKind.Relative))
            };
            priprava.Children.Add(sur);
        }

      
       
    }
}
