using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SecretMenu
{
    public partial class Nearby : PhoneApplicationPage
    {
        public Nearby() {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            if (Helpers.lstNearby == null || Helpers.lstNearby.Count == 0) {
                Helpers.get(Helpers.urlNearby, (json) => {
                    Helpers.lstNearby = JsonConvert.DeserializeObject<ObservableCollection<FoodItem>>(json);
                    Debug.WriteLine("Main Page fetching nearby:" + Helpers.lstNearby.Count);
                    pgBar.Visibility = System.Windows.Visibility.Collapsed;
                    this.DataContext = Helpers.lstNearby;
                });
            }
            else {
                pgBar.Visibility = System.Windows.Visibility.Collapsed;
                this.DataContext = Helpers.lstNearby;
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            Grid selection = sender as Grid;
            FoodItem item = selection.DataContext as FoodItem;
            Debug.WriteLine("Tapped on: " + item.upic);
            Helpers.lastSelection = item;
            NavigationService.Navigate(new Uri("/ItemPage.xaml", UriKind.Relative));
        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e) {

        }
    }
}