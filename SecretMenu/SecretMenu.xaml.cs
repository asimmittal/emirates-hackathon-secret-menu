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

namespace SecretMenu.Assets.Tiles
{
    public partial class SecretMenu : PhoneApplicationPage
    {
        
        public SecretMenu() {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e) {
            if (Helpers.lstItems == null || Helpers.lstItems.Count == 0) {
                Helpers.get(Helpers.urlCrumbs, (json) => {
                    Helpers.lstItems = JsonConvert.DeserializeObject<ObservableCollection<FoodItem>>(json);
                    pgBar.Visibility = System.Windows.Visibility.Collapsed;
                    this.DataContext = Helpers.lstItems;
                });
            }
            else {
                pgBar.Visibility = System.Windows.Visibility.Collapsed;
                this.DataContext = Helpers.lstItems;
            }
        }
    }
}