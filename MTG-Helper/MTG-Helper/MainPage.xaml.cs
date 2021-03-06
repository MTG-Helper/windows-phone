﻿using System;
using System.Collections.Generic;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MTG_Helper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Scoreboard));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Contadores));
        }

        private void Buscador_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Buscador));
        }
        private void BuscadorImagen_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(BuscadorImagen));
        }
        private void Scoreboard_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Scoreboard));
        }

        private void Coin_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Coin));
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Dice));
        }
    }
}
