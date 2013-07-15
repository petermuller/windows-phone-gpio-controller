using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Text;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace windows_phone_gpio_controller
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        int toggle, toggle1,toggle2,toggle3,toggle4,toggle5,toggle6,toggle7 = 0;
        public PanoramaPage1()
        {
            InitializeComponent();
        }

        public Color Color { get; set; }

        private void Panorama_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutUS.xaml", UriKind.Relative));
        }

        private void HelpGPIO_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpGPIOControl.xaml", UriKind.Relative));
        }

        private void Location_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PinLocation.xaml", UriKind.Relative));
        }

        private void GPIO0_Click(object sender, RoutedEventArgs e)
        {
            if (toggle % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO0.Background = ButtonSolidColorBrush;
                GPIO0.Content = "GPIO 0 Output";
                toggle++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO0.Background = ButtonSolidColorBrush;
                GPIO0.Content = "GPIO 0 Input";
                toggle++;
            }

            
        }

        private void GPIO1_Click(object sender, RoutedEventArgs e)
        {
            if (toggle1 % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO1.Background = ButtonSolidColorBrush;
                GPIO1.Content = "GPIO 1 Output";
                toggle1++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO1.Background = ButtonSolidColorBrush;
                GPIO1.Content = "GPIO 1 Input";
                toggle1++;
            }
        }

        private void GPIO2_Click(object sender, RoutedEventArgs e)
        {
            if (toggle2 % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO2.Background = ButtonSolidColorBrush;
                GPIO2.Content = "GPIO 2 Output";
                toggle2++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO2.Background = ButtonSolidColorBrush;
                GPIO2.Content = "GPIO 2 Input";
                toggle2++;
            }
        }

        private void GPIO3_Click(object sender, RoutedEventArgs e)
        {
            if (toggle3 % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO3.Background = ButtonSolidColorBrush;
                GPIO3.Content = "GPIO 3 Output";
                toggle3++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO3.Background = ButtonSolidColorBrush;
                GPIO3.Content = "GPIO 3 Input";
                toggle3++;
            }
        }

        private void GPIO4_Click(object sender, RoutedEventArgs e)
        {
            if (toggle4 % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO4.Background = ButtonSolidColorBrush;
                GPIO4.Content = "GPIO 4 Output";
                toggle4++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO4.Background = ButtonSolidColorBrush;
                GPIO4.Content = "GPIO 4 Input";
                toggle4++;
            }
        }

        private void GPIO5_Click(object sender, RoutedEventArgs e)
        {
            if (toggle5 % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO5.Background = ButtonSolidColorBrush;
                GPIO5.Content = "GPIO 5 Output";
                toggle5++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO5.Background = ButtonSolidColorBrush;
                GPIO5.Content = "GPIO 5 Input";
                toggle5++;
            }
        }

        private void GPIO6_Click(object sender, RoutedEventArgs e)
        {
            if (toggle6 % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO6.Background = ButtonSolidColorBrush;
                GPIO6.Content = "GPIO 6 Output";
                toggle6++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO6.Background = ButtonSolidColorBrush;
                GPIO6.Content = "GPIO 6 Input";
                toggle6++;
            }
        }

        private void GPIO7_Click(object sender, RoutedEventArgs e)
        {
            if (toggle7 % 2 == 0)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO7.Background = ButtonSolidColorBrush;
                GPIO7.Content = "GPIO 7 Output";
                toggle7++;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO7.Background = ButtonSolidColorBrush;
                GPIO7.Content = "GPIO 7 Input";
                toggle7++;
            }
        }

    }
}