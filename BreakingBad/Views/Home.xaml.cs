using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BreakingBad
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }


        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((MainPage)App.Current.RootVisual).NavigationGrid.Visibility = System.Windows.Visibility.Collapsed;
            ((MainPage)App.Current.RootVisual).ContentBorder.Margin = new Thickness(0, 0, 0, 0);
            ((MainPage)App.Current.RootVisual).ContentBorder.Height = (((MainPage)App.Current.RootVisual).ContentBorder.Height) + 50;
        }

        private void Intro_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch(Intro.CurrentState)
            {
                case MediaElementState.Playing:
                    Intro.Pause();
                    //ImgPause.Visibility = System.Windows.Visibility.Visible;
                    break;
                case MediaElementState.Paused:
                    Intro.Play();
                    //ImgPause.Visibility = System.Windows.Visibility.Collapsed;
                    break;
            }
        }

        private void Intro_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (Intro.CurrentState == MediaElementState.Paused)
            {
                ImgPause.Visibility = System.Windows.Visibility.Visible;
            }
            else if (Intro.CurrentState == MediaElementState.Playing)
                ImgPause.Visibility = System.Windows.Visibility.Collapsed;
        }   

        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MainPage)App.Current.RootVisual).ContentFrame.Source = new Uri("/About", UriKind.RelativeOrAbsolute);
            ((MainPage)App.Current.RootVisual).NavigationGrid.Visibility = System.Windows.Visibility.Visible;
            ((MainPage)App.Current.RootVisual).ContentBorder.Margin = new Thickness(0, 50, 0, 0);
            ((MainPage)App.Current.RootVisual).ContentBorder.Height = (((MainPage)App.Current.RootVisual).ContentBorder.Height) - 50;
        }

        private void Intro_MediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("terminou");
            ((MainPage)App.Current.RootVisual).ContentFrame.Source = new Uri("/About", UriKind.RelativeOrAbsolute);
        }

        private void Intro_MediaOpened(object sender, RoutedEventArgs e)
        {
            ((MediaElement)sender).Position = new TimeSpan(0, 0, 50);
            MessageBox.Show("abriu o video");
        }
    }
}