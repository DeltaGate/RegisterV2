using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegisterV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string price;
        Double priceOverall = 0.00;
        int discountAmmount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }


        //Logic to recieve catagory found items

        public void ReceiveDoubleValue(double value)
        {
            // Do something with the received value
            // For example, display it in a TextBox named "doubleTextBox"
            priceCount.Text = Convert.ToString(value);
            price = price + value.ToString();
        }



        // Button Controls & action logic

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn1.Content;
            priceCount.Text = price;

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn2.Content;
            priceCount.Text = price;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn3.Content;
            priceCount.Text = price;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn4.Content;
            priceCount.Text = price;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn5.Content;
            priceCount.Text = price;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn6.Content;
            priceCount.Text = price;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn7.Content;
            priceCount.Text = price;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn8.Content;
            priceCount.Text = price;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn9.Content;
            priceCount.Text = price;
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            price = price + btn0.Content;
            priceCount.Text = price;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            priceOverall = priceOverall + Convert.ToDouble(price);
            priceCount.Text = priceOverall.ToString();
            Label newLabel = new Label();
            newLabel.FontSize = 35;
            newLabel.Content = "  £ " + price;
            receiptList.Children.Add(newLabel);
            price = price.Substring(0, 0);

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            price = price.Substring(0, 0);
            priceCount.Text = price;
        }
        // btnDot to be removed in favour of auto function in future
        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            price = price + btnDot.Content;
            priceCount.Text = price;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            price = price.Substring(0, price.Length - 1);
            priceCount.Text = price;
        }

        // Basic Logic for applying a discount to overall price, needs amending to make user control more clear and to disallow control errors as its currently
        // quite confusing to use.

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {
            discountAmmount = Convert.ToInt32(priceCount.Text);
            double heldNum = (priceOverall * discountAmmount) / 100;
            string heldNumConvert = heldNum.ToString();
            Label newLabel = new Label();
            newLabel.FontSize = 35;
            newLabel.Content = "  Discount % " + priceCount.Text;
            receiptList.Children.Add(newLabel);
            Label newLabel1 = new Label();
            newLabel1.FontSize = 35;
            newLabel1.Content = "  - £ " + heldNumConvert;
            receiptList.Children.Add(newLabel1);
            priceOverall = priceOverall - ((priceOverall * discountAmmount) / 100);
            priceCount.Text = priceOverall.ToString();
            price = price.Substring(0, 0);
        }

        private void btnCatagorySearch_Click(object sender, RoutedEventArgs e)
        {
            Catagorys catagorys = new Catagorys();
            catagorys.Show();
        }
    }
}