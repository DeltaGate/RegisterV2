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
        public CatagorySelected()
        {
            InitializeComponent();
            sqlHit();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void sqlHit()
        {
            string cn_string = Properties.Settings.Default.regDBConnectionString;

            SqlConnection cn_connection = new SqlConnection(cn_string);

            if (cn_connection.State != ConnectionState.Open)
            {
                cn_connection.Open();
            }

            string sql_Text = "SELECT * FROM MOCK_DATA;";

            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            adapter.Fill(tbl);

            lstCat.Items.Clear();
            lstCat.ItemsSource = tbl.DefaultView;
            lstCat.DisplayMemberPath = "item_name" + " " + "stock";

        }
    }



}
