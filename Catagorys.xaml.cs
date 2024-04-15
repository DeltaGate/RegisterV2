using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegisterV2
{
    /// <summary>
    /// Interaction logic for Catagorys.xaml
    /// </summary>
    public partial class Catagorys : Window
    {
        public Catagorys()
        {
            InitializeComponent();
        }

        private void Fruit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CatagorySelected catagorySelected = new CatagorySelected("'fruit'");
            catagorySelected.Show();
            var currentWindow = Window.GetWindow(this);
            currentWindow.Close();
        }

        private void Veg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CatagorySelected catagorySelected = new CatagorySelected("'veg'");
            catagorySelected.Show();
            var currentWindow = Window.GetWindow(this);
            currentWindow.Close();
        }

        private void Backery_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CatagorySelected catagorySelected = new CatagorySelected("'bakery'");
            catagorySelected.Show();
            var currentWindow = Window.GetWindow(this);
            currentWindow.Close();
        }

        private void Tech_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CatagorySelected catagorySelected = new CatagorySelected("'tech'");
            catagorySelected.Show();
            var currentWindow = Window.GetWindow(this);
            currentWindow.Close();
        }
    }
}
