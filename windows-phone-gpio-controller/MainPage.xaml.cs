using System;
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

        private void TextBox_Portnumber(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            try
            {
                String host = HostAddressInput.Text;
                int port = Convert.ToInt32(PortNumberInput.Text);
                sc.Connect(host, port);
                sc.Send("Testing!");
                PhoneApplicationService.Current.State["sc"] = sc;
                String success = sc.Receive();
                if (success == "Success")
                {
                    NavigationService.Navigate(new Uri("/GPIOControl.xaml", UriKind.Relative));
                }
            }
            catch
            {
                //Debugging error: print something to the screen (or not go to next page)
            }
            
        }

        private void Help_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpConnect.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GPIOControl.xaml", UriKind.Relative));
            PhoneApplicationService.Current.State["sc"] = sc;
        }
    }
}