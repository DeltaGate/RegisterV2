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

using System.Data.SqlClient;
using Microsoft.Win32;
using System.Data; //SQL server local db

namespace RegisterV2
{
    /// <summary>
    /// Interaction logic for CatagorySelected.xaml
    /// </summary>
    public partial class CatagorySelected : Window
    {
        public CatagorySelected(string catagorySelectedPull)
        {
            InitializeComponent();
            sqlHit(catagorySelectedPull);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Logic for accessing data and drawing data

        private void sqlHit(string catagorySelectedPull)
        {
            string cn_string = Properties.Settings.Default.regDBConnectionString;



           // string sqlQuery = "SELECT ColumnName FROM TableName WHERE Condition = @param"; // SQL query to retrieve the desired value
           // object result = null; // Variable to store the result


            //    SqlCommand command = new SqlCommand(sqlQuery, connection);
            //    command.Parameters.AddWithValue("@param", yourParameterValue); // Add parameters if needed



                SqlConnection cn_connection = new SqlConnection(cn_string);

            if (cn_connection.State != ConnectionState.Open)
            {
                cn_connection.Open();
            }

            string sql_Text = "SELECT * FROM goods WHERE CATEGORY = " + catagorySelectedPull;

            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            adapter.Fill(tbl);

            //add adition column to concat values from item and price to show both in catagory selection

            tbl.Columns.Add("DisplayColumn", typeof(string));
            foreach (DataRow row in tbl.Rows)
            {
                row["DisplayColumn"] = row["item_name"].ToString() + "                      £" + row["price"].ToString();
            }

            lstCat.Items.Clear();
            lstCat.ItemsSource = tbl.DefaultView;
            lstCat.DisplayMemberPath = "DisplayColumn";

        }

        private void lstCat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Check if an item is actually selected
            if (lstCat.SelectedItem != null)
            {
                // logic finds the main window within method so it can be called.
                MainWindow otherWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();


                DataRowView selectedRow = lstCat.SelectedItem as DataRowView;


                double valueToSend = Convert.ToDouble(selectedRow["price"]); 

                // Pass the double value to the other window
                otherWindow.ReceiveDoubleValue(valueToSend);

                // close current window when done
                var currentWindow = Window.GetWindow(this);
                currentWindow.Close();

            }
        }
    }



}
