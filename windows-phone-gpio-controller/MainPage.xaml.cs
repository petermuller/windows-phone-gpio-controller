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
        Communicator c;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_HostAddress(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_Username(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            String host = HostAddressInput.Text;
            int port = Convert.ToInt32(UsernameInput.Text);
            c = new Communicator(host, port);
            c.sendCommand("Nailed it");
        }

        private void TextBox_Password(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}