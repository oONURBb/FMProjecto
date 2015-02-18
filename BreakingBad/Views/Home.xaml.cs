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


        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            /*((MainPage)App.Current.RootVisual).ContentBorder.Margin = new Thickness(0,0,0,0);
            ((MainPage)App.Current.RootVisual).ContentBorder.Height = 768;*/
        }

        private void Intro_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Intro.CurrentState == MediaElementState.Playing)
            {
                Intro.Pause();
            }
            else
                Intro.Play();
        }

        private void Intro_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if(Intro.CurrentState == MediaElementState.Paused)
            {
                ImgPause.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}