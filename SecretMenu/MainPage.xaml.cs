using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SecretMenu.Resources;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SecretMenu
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage() {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void gridTakePhoto_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            NavigationService.Navigate(new Uri("/TakePhoto.xaml",UriKind.Relative));
        }

        private void gridSecretMenu_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            NavigationService.Navigate(new Uri("/SecretMenu.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            if (Helpers.lstItems == null || Helpers.lstItems.Count == 0) {
                Helpers.get(Helpers.urlCrumbs, (json) => {
                    Helpers.lstItems = JsonConvert.DeserializeObject<ObservableCollection<FoodItem>>(json);
                    Debug.WriteLine("Main Page fetching crumbs:" + Helpers.lstItems.Count);
                });
            }

            if (Helpers.lstNearby == null || Helpers.lstNearby.Count == 0) {
                Helpers.get(Helpers.urlNearby, (json) => {
                    Helpers.lstNearby = JsonConvert.DeserializeObject<ObservableCollection<FoodItem>>(json);
                    Debug.WriteLine("Main Page fetching nearby:" + Helpers.lstNearby.Count);
                });
            }
        }

        private void gridNearby_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            NavigationService.Navigate(new Uri("/Nearby.xaml", UriKind.Relative));
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