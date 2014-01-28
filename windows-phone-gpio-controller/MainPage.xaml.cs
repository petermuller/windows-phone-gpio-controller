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
using System.IO.IsolatedStorage;
using System.IO;

namespace windows_phone_gpio_controller
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Class variables
        //For the connection
        SocketClient sc = new SocketClient();
        /*Memory for pins settings*/
        private IsolatedStorageSettings storage = IsolatedStorageSettings.ApplicationSettings;


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            //Read host data from file if it exists.
            try
            {
                HostAddressInput.Text = (string)storage["host"];
            }
            catch
            {
                //Nothing to do here
            }

#if DEBUG
            NoConnect.Visibility = Visibility.Visible;
#endif
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
#if DEBUG
                //HostAddressInput.Text = "raspberrypiman.student.rit.edu";
                //PortNumberInput.Text = "9001";
#endif
                String host = HostAddressInput.Text;
                int port = Convert.ToInt32(PortNumberInput.Text);
                sc.Connect(host, port);
                sc.Send("Testing!");

                //save host
                storage["host"] = HostAddressInput.Text;

                //Save the socket client for other screens
                PhoneApplicationService.Current.State["sc"] = sc;
                String success = sc.Receive();

                if (success == "yes!!")
                {
                    ConnectText.Visibility = Visibility.Collapsed;
                    NavigationService.Navigate(new Uri("/GPIOControl.xaml", UriKind.Relative));
                }
            }
            catch
            {
                //Debugging error: print something to the screen (or not go to next page)
                ConnectText.Visibility = Visibility.Visible;
            }
            
        }

        private void Help_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpConnect.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            storage["host"] = HostAddressInput.Text;
            NavigationService.Navigate(new Uri("/GPIOControl.xaml", UriKind.Relative));
            PhoneApplicationService.Current.State["sc"] = sc;
        }
    }
}