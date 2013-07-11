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
<<<<<<< HEAD
=======
        //Class variables
       // Communicator c;
>>>>>>> Background And Cleaning Up UI

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
            NavigationService.Navigate(new Uri("/GPIOControl.xaml", UriKind.Relative));
        }

        private void TextBox_Password(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save button works!");
            //Do work for your application here.
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings button works!");
            //Do work for your application here.
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu item 1 works!");
            //Do work for your application here.
        }

        private void MenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu item 2 works!");
            //Do work for your application here.
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
        
            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);
        
            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }
    }
}