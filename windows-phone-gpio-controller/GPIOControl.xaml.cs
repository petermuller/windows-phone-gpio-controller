using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Text;
using System.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace windows_phone_gpio_controller
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        /*For these toggles: false correlates to our previous even numbers; true to odd.*/
        bool toggle, toggle1, toggle2, toggle3, toggle4, toggle5, toggle6, toggle7 = false;
        SocketClient sc = (SocketClient)PhoneApplicationService.Current.State["sc"];
        bool thread0, thread1, thread2, thread3, thread4, thread5, thread6, thread7 = false;

        int REFRESH_TIME = 250; //milliseconds or 1/4 of a second


        public PanoramaPage1()
        {
            InitializeComponent();
        }

        public Color Color { get; set; }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (toggle)
            {
                sc.Send("set,11,i  ");
                Thread.Sleep(20);
            }
           
            if (toggle1)
            {
                sc.Send("set,12,i  ");
                Thread.Sleep(20);
            }
            
            if (toggle2)
            {
                sc.Send("set,13,i  ");
                Thread.Sleep(20);
            }
        
            if (toggle3)
            {
                sc.Send("set,15,i  ");
                Thread.Sleep(20);
            }
            
            if (toggle4)
            {
                sc.Send("set,16,i  ");
                Thread.Sleep(20);
            }
            
            if (toggle5)
            {
                sc.Send("set,18,i  ");
                Thread.Sleep(20);
            }
        
            if (toggle6)
            {
                sc.Send("set,22,i  ");
                Thread.Sleep(20);
            }
            
            if (toggle7)
            {
                sc.Send("set,7,i   ");
                Thread.Sleep(20);
            }
            
            sc.Close();
        }

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
            if (!toggle)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO0.Background = ButtonSolidColorBrush;
                GPIO0.Content = "GPIO 0 Output";
                Slider0.Visibility = Visibility.Visible;
                GPIO0TXT.Visibility = Visibility.Visible;
                Monitor0.Visibility = Visibility.Collapsed;
                GPIO0InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,11,o  ");
                toggle = true; ;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO0.Background = ButtonSolidColorBrush;
                GPIO0.Content = "GPIO 0 Input";
                Monitor0.Visibility = Visibility.Visible;
                GPIO0InTXT.Visibility = Visibility.Visible;
                Slider0.Visibility = Visibility.Collapsed;
                GPIO0TXT.Visibility = Visibility.Collapsed;
                sc.Send("set,11,i  ");
                toggle=false;
                if (!thread0)
                {
                    Thread t = new Thread(() => listen(11, 0));
                    t.Start();
                    thread0 = true;
                }
            }
        }

        private void GPIO1_Click(object sender, RoutedEventArgs e)
        {
            if (!toggle1)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO1.Background = ButtonSolidColorBrush;
                GPIO1.Content = "GPIO 1 Output";
                Slider1.Visibility = Visibility.Visible;
                GPIO1TXT.Visibility = Visibility.Visible;
                Monitor1.Visibility = Visibility.Collapsed;
                GPIO1InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,12,o  ");
                toggle1=true;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO1.Background = ButtonSolidColorBrush;
                GPIO1.Content = "GPIO 1 Input";
                Slider1.Visibility = Visibility.Collapsed;
                GPIO1TXT.Visibility = Visibility.Collapsed;
                Monitor1.Visibility = Visibility.Visible;
                GPIO1InTXT.Visibility = Visibility.Visible;
                sc.Send("set,12,i  ");
                toggle1=false;
                if (!thread1)
                {
                    Thread t = new Thread(() => listen(12, 1));
                    t.Start();
                    thread1 = true;
                }
            }
        }

        private void GPIO2_Click(object sender, RoutedEventArgs e)
        {
            if (!toggle2)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO2.Background = ButtonSolidColorBrush;
                GPIO2.Content = "GPIO 2 Output";
                Slider2.Visibility = Visibility.Visible;
                GPIO2TXT.Visibility = Visibility.Visible;
                Monitor2.Visibility = Visibility.Collapsed;
                GPIO2InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,13,o  ");
                toggle2=true;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO2.Background = ButtonSolidColorBrush;
                GPIO2.Content = "GPIO 2 Input";
                Slider2.Visibility = Visibility.Collapsed;
                GPIO2TXT.Visibility = Visibility.Collapsed;
                Monitor2.Visibility = Visibility.Visible;
                GPIO2InTXT.Visibility = Visibility.Visible;
                sc.Send("set,13,i  ");
                toggle2=false;
                if (!thread2)
                {
                    Thread t = new Thread(() => listen(13, 2));
                    t.Start();
                    thread2 = true;
                }
            }
        }

        private void GPIO3_Click(object sender, RoutedEventArgs e)
        {
            if (!toggle3)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO3.Background = ButtonSolidColorBrush;
                GPIO3.Content = "GPIO 3 Output";
                Slider3.Visibility = Visibility.Visible;
                GPIO3TXT.Visibility = Visibility.Visible;
                Monitor3.Visibility = Visibility.Collapsed;
                GPIO3InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,15,o  ");
                toggle3=true;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO3.Background = ButtonSolidColorBrush;
                GPIO3.Content = "GPIO 3 Input";
                Slider3.Visibility = Visibility.Collapsed;
                GPIO3TXT.Visibility = Visibility.Collapsed;
                Monitor3.Visibility = Visibility.Visible;
                GPIO3InTXT.Visibility = Visibility.Visible;
                sc.Send("set,15,i  ");
                toggle3=false;
                if (!thread3)
                {
                    Thread t = new Thread(() => listen(15, 3));
                    t.Start();
                    thread3 = true;
                }
            }
        }

        private void GPIO4_Click(object sender, RoutedEventArgs e)
        {
            if (!toggle4)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO4.Background = ButtonSolidColorBrush;
                GPIO4.Content = "GPIO 4 Output";
                Slider4.Visibility = Visibility.Visible;
                GPIO4TXT.Visibility = Visibility.Visible;
                Monitor4.Visibility = Visibility.Collapsed;
                GPIO4InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,16,o  ");
                toggle4=true;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO4.Background = ButtonSolidColorBrush;
                GPIO4.Content = "GPIO 4 Input";
                Slider4.Visibility = Visibility.Collapsed;
                GPIO4TXT.Visibility = Visibility.Collapsed;
                Monitor4.Visibility = Visibility.Visible;
                GPIO4InTXT.Visibility = Visibility.Visible;
                sc.Send("set,16,i  ");
                toggle4=false;
                if (!thread4)
                {
                    Thread t = new Thread(() => listen(16, 4));
                    t.Start();
                    thread4 = true;
                }
            }
        }

        private void GPIO5_Click(object sender, RoutedEventArgs e)
        {
            if (!toggle5)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO5.Background = ButtonSolidColorBrush;
                GPIO5.Content = "GPIO 5 Output";
                Slider5.Visibility = Visibility.Visible;
                GPIO5TXT.Visibility = Visibility.Visible;
                Monitor5.Visibility = Visibility.Collapsed;
                GPIO5InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,18,o  ");
                toggle5=true;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO5.Background = ButtonSolidColorBrush;
                GPIO5.Content = "GPIO 5 Input";
                Slider5.Visibility = Visibility.Collapsed;
                GPIO5TXT.Visibility = Visibility.Collapsed;
                Monitor5.Visibility = Visibility.Visible;
                GPIO5InTXT.Visibility = Visibility.Visible;
                sc.Send("set,18,i  ");
                toggle5=false;
                if (!thread5)
                {
                    Thread t = new Thread(() => listen(18, 5));
                    t.Start();
                    thread5 = true;
                }
            }
        }

        private void GPIO6_Click(object sender, RoutedEventArgs e)
        {
            if (!toggle6)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO6.Background = ButtonSolidColorBrush;
                GPIO6.Content = "GPIO 6 Output";
                Slider6.Visibility = Visibility.Visible;
                GPIO6TXT.Visibility = Visibility.Visible;
                Monitor6.Visibility = Visibility.Collapsed;
                GPIO6InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,22,o  ");
                toggle6=true;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO6.Background = ButtonSolidColorBrush;
                GPIO6.Content = "GPIO 6 Input";
                Slider6.Visibility = Visibility.Collapsed;
                GPIO6TXT.Visibility = Visibility.Collapsed;
                Monitor6.Visibility = Visibility.Visible;
                GPIO6InTXT.Visibility = Visibility.Visible;
                sc.Send("set,22,i  ");
                toggle6=false;
                if (!thread6)
                {
                    Thread t = new Thread(() => listen(22, 6));
                    t.Start();
                    thread6 = true;
                }
            }
        }

        private void GPIO7_Click(object sender, RoutedEventArgs e)
        {
            if (!toggle7)
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(225, 195, 12, 70);
                GPIO7.Background = ButtonSolidColorBrush;
                GPIO7.Content = "GPIO 7 Output";
                Slider7.Visibility = Visibility.Visible;
                GPIO7TXT.Visibility = Visibility.Visible;
                Monitor7.Visibility = Visibility.Collapsed;
                GPIO7InTXT.Visibility = Visibility.Collapsed;
                sc.Send("set,7,o   ");
                toggle7=true;
            }
            else
            {
                System.Windows.Media.SolidColorBrush ButtonSolidColorBrush = new System.Windows.Media.SolidColorBrush();
                ButtonSolidColorBrush.Color = Color.FromArgb(0, 0, 0, 225);
                GPIO7.Background = ButtonSolidColorBrush;
                GPIO7.Content = "GPIO 7 Input";
                Slider7.Visibility = Visibility.Collapsed;
                GPIO7TXT.Visibility = Visibility.Collapsed;
                Monitor7.Visibility = Visibility.Visible;
                GPIO7InTXT.Visibility = Visibility.Visible;
                sc.Send("set,7,i   ");
                toggle7=false;
                if (!thread7)
                {
                    Thread t = new Thread(() => listen(7, 7));
                    t.Start();
                    thread7 = true;
                }
            }
        }

        private void Slider_GPIO0(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,11," + formatNumber(Math.Truncate(Slider0.Value)));
        }

        private void Slider_GPIO1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,12," + formatNumber(Math.Truncate(Slider1.Value)));
        }

        private void Slider_GPIO2(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,13," + formatNumber(Math.Truncate(Slider2.Value)));
        }

        private void Slider_GPIO3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,15," + formatNumber(Math.Truncate(Slider3.Value)));
        }

        private void Slider_GPIO4(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,16," + formatNumber(Math.Truncate(Slider4.Value)));
        }

        private void Slider_GPIO5(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,18," + formatNumber(Math.Truncate(Slider5.Value)));
        }

        private void Slider_GPIO6(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,22," + formatNumber(Math.Truncate(Slider6.Value)));
        }

        private void Slider_GPIO7(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sc.Send("volt,7," + formatNumber(Math.Truncate(Slider7.Value)));
        }

        private String formatNumber(double number)
        {
            String val;
            if (number < 10)
            {
                val = "0" + number.ToString();
            }
            else
            {
                val = number.ToString();
            }
            return val;
        }

        private void listen(int pinNumber, int monitor)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Thread.Sleep(REFRESH_TIME);
                string message = "readIn," + pinNumber.ToString();
                while (message.Length < 10)
                {
                    message += " ";
                }
                sc.Send(message);
                message = sc.Receive(); //reuse var to avoid using more space
                try
                {
                    string[] m = message.Trim().Split(',');
                    if (m[0] == "STOP!")
                    {
                        //Kill current thread
                        isRunning = false;
                        //allow new threads to be spawned later
                        if (pinNumber == 11)
                        {
                            thread0 = false;
                        }
                        if (pinNumber == 12)
                        {
                            thread1 = false;
                        }
                        if (pinNumber == 13)
                        {
                            thread2 = false;
                        }
                        if (pinNumber == 15)
                        {
                            thread3 = false;
                        }
                        if (pinNumber == 16)
                        {
                            thread4 = false;
                        }
                        if (pinNumber == 18)
                        {
                            thread5 = false;
                        }
                        if (pinNumber == 22)
                        {
                            thread6 = false;
                        }
                        if (pinNumber == 7)
                        {
                            thread7 = false;
                        }
                    }

                    if (m[0] == "1")
                    {
                        switch (monitor)
                        {
                            case 0:
                                Dispatcher.BeginInvoke(() =>
                                    {
                                        Monitor0.Text = "High";
                                    });
                                break;
                            case 1:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor1.Text = "High";
                                });
                                break;
                            case 2:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor2.Text = "High";
                                });
                                break;
                            case 3:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor3.Text = "High";
                                });
                                break;
                            case 4:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor4.Text = "High";
                                });
                                break;
                            case 5:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor5.Text = "High";
                                });
                                break;
                            case 6:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor6.Text = "High";
                                });
                                break;
                            case 7:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor7.Text = "High";
                                });
                                break;
                        }
                    }
                    else
                    {
                        switch (monitor)
                        {
                            case 0:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor0.Text = "Low";
                                });
                                break;
                            case 1:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor1.Text = "Low";
                                });
                                break;
                            case 2:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor2.Text = "Low";
                                });
                                break;
                            case 3:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor3.Text = "Low";
                                });
                                break;
                            case 4:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor4.Text = "Low";
                                });
                                break;
                            case 5:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor5.Text = "Low";
                                });
                                break;
                            case 6:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor6.Text = "Low";
                                });
                                break;
                            case 7:
                                Dispatcher.BeginInvoke(() =>
                                {
                                    Monitor7.Text = "Low";
                                });
                                break;
                        }
                    }
                }
                catch {
                    break;
                }
            }
        }

    }
}