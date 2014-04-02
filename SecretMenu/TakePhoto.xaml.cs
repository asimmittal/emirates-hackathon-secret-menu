using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;

namespace SecretMenu
{
    public partial class TakePhoto : PhoneApplicationPage
    {
        public TakePhoto() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if(slider != null) txtValue.Content = "I paid... $" + (int)(slider.Value);
        }

        private void CheckBox_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            CheckBox chkBox = (CheckBox)sender;
            Debug.WriteLine(chkBox.Content + " is " + chkBox.IsChecked);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (txtName.Text.Length == 0) {
                txtName.Focus();
            }
            else {
                FoodItem item = new FoodItem();
                item.country = "Turkey";
                item.date = "Today";
                item.dish = txtName.Text;
                item.distance = 3;
                item.flagGluten = (bool)chkGluten.IsChecked;
                item.flagKosher = (bool)chkKosher.IsChecked;
                item.flagVegetarian = (bool)chkVeg.IsChecked;
                item.id = -1;
                item.pic = "Assets/mypic.jpg";
                item.place = "Gelatario";
                item.user = "Diana";
                item.location = "Hagia Sofia, Istanbul";
                item.meal = "lunch";
                item.likes = 0;
                Helpers.lstItems.Insert(0, item);
                Debug.WriteLine("Len:" + Helpers.lstItems.Count);
                NavigationService.GoBack();
            }
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e) {
            txtName.Text = "Ice Cream Sunday";
        }
    }
}