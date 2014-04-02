using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMenu
{
    public class FoodItem
    {
        public int id { get; set; }
        public string pic { get; set; }
        public string dish { get; set; }
        public string date { get; set; }
        public string location { get; set; }
        public string country { get; set; }

        public string distString { get; set; }
        private double _dist;
        public double distance {
            get {
                return _dist;
            }
            set {
                _dist = value;
                distString = value + " miles";
            }
        }
        
        public string upic { get; set; }
        private string _user;
        public string user {
            get {
                return _user;
            }
            set {
                upic = "Assets/" + value + ".jpg";
                _user = value;
            }
        }
        public int likes { get; set; }
        public string place { get; set; }
        public bool flagGluten { get; set; }
        public bool flagKosher { get; set; }
        public bool flagVegetarian { get; set; }
        public string color { get; set; }
        public string mealString { get; set; }
        public string meal { 
            set {
                switch (value) {
                    case "breakfast": color = "#FFC926"; mealString = "B"; break;
                    case "lunch": color = "#FF6426"; mealString = "L"; break;
                    case "dinner": color = "#9700B5"; mealString = "D"; break;
                }
            }
        }
    }
}
