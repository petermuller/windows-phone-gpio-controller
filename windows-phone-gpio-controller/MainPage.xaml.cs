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
        //For the storage
        static IsolatedStorageFile Storage = IsolatedStorageFile.GetUserStoreForApplication();
        StreamWriter writer;
        StreamReader reader;


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            //Read host data from file if it exists.
            try
            {
                reader = new StreamReader(new IsolatedStorageFileStream("hp.txt", FileMode.OpenOrCreate, Storage));
                HostAddressInput.Text = reader.ReadToEnd().Trim();
                reader.Close();
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

                //Save the socket client for other screens
                PhoneApplicationService.Current.State["sc"] = sc;
                String success = sc.Receive();

                //Write host data to file storage
                Storage.DeleteFile("hp.txt");
                writer = new StreamWriter(new IsolatedStorageFileStream("hp.txt", FileMode.OpenOrCreate, Storage));
                writer.Write(HostAddressInput.Text);
                writer.Close();
                //end write to file storage

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
            Storage.DeleteFile("hp.txt");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storage.DeleteFile("hp.txt");
            writer = new StreamWriter(new IsolatedStorageFileStream("hp.txt", FileMode.OpenOrCreate, Storage));
            writer.Write(HostAddressInput.Text);
            writer.Close();
            NavigationService.Navigate(new Uri("/GPIOControl.xaml", UriKind.Relative));
            PhoneApplicationService.Current.State["sc"] = sc;
        }
    }
}