﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using windows_phone_gpio_controller.Resources;

namespace windows_phone_gpio_controller
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Class variables
        SocketClient sc = new SocketClient();

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void TextBox_HostAddress(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_Username(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            try
            {
              //  String host = HostAddressInput.Text;
              //  int port = Convert.ToInt32(PortInput.Text);
              //  sc.Connect(host, port);
              //  sc.Send("Testing!");
            }
            catch
            {
                //Debugging error: print something to the screen (or not go to next page)
            }
            NavigationService.Navigate(new Uri("/GPIOControl.xaml", UriKind.Relative));
        }

        private void Help_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpConnect.xaml", UriKind.Relative));
        }
    }
}