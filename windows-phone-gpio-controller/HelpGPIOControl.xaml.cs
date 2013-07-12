using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace windows_phone_gpio_controller
{
    public partial class HelpGPIOControl : PhoneApplicationPage
    {
        public HelpGPIOControl()
        {
            InitializeComponent();
        }

        private void Goback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}