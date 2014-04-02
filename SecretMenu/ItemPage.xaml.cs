using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace SecretMenu
{
    public partial class ItemPage : PhoneApplicationPage
    {
        bool isHeartPink = false;

        public ItemPage() {
            InitializeComponent();
            isHeartPink = false;
        }

        private void imgHeart_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            imgHeart.Source = (isHeartPink)? new BitmapImage(new Uri(@"Assets/heart-filled-white.png",UriKind.Relative)): new BitmapImage(new Uri(@"Assets/heart-filled-pink.png",UriKind.Relative));
            isHeartPink = !isHeartPink;
            if (Helpers.lastSelection != null) {
                Helpers.lastSelection.likes += (isHeartPink) ? 1 : -1;
                if (Helpers.lastSelection.likes < 0) Helpers.lastSelection.likes = 0;
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e) {
            if (Helpers.lastSelection != null) {
                FoodItem selected = Helpers.lastSelection;
                imgUser.Source = new BitmapImage(new Uri(selected.upic,UriKind.Relative));
                txtPlace.Text = selected.place;
                txtLocation.Text = selected.location;
                pic.Source = new BitmapImage(new Uri(selected.pic,UriKind.RelativeOrAbsolute));

                string capName = char.ToUpper(selected.user[0]) + selected.user.Substring(1);
                btnMenu.Content = "View " + capName + "'s Secret Menu";
                if (selected.flagGluten) iconGluten.Visibility = System.Windows.Visibility.Visible; else iconGluten.Visibility = System.Windows.Visibility.Collapsed;
                if (selected.flagKosher) iconKosher.Visibility = System.Windows.Visibility.Visible; else iconKosher.Visibility = System.Windows.Visibility.Collapsed;
                if (selected.flagVegetarian) iconVeg.Visibility = System.Windows.Visibility.Visible; else iconVeg.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}