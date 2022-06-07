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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Projekt_semestralny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrig();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TQ55N08;Initial Catalog=NewDB;Integrated Security=True");

        public void LoadGrig()
        {
            SqlCommand cmd = new SqlCommand("select * from FirstTable", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Datagrid.ItemsSource = dt.DefaultView;
        }
        public void clearData()
        {
            Firstname_txt.Clear();
            Secondname_txt.Clear();
            Number_txt.Clear();
            Email_txt.Clear();

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }
    }
}
