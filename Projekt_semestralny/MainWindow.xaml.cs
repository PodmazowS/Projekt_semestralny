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
            con.Close();
            Datagrid.ItemsSource = dt.DefaultView;
        }
        public void clearData()
        {
            Firstname_txt.Clear();
            Secondname_txt.Clear();
            Number_txt.Clear();
            Email_txt.Clear();

        }
        public bool isValid()
        {
            if(Firstname_txt.Text == String.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Secondname_txt.Text == String.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Number_txt.Text == String.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Email_txt.Text == String.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
         clearData();
            
          
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO FirstTable VALUES (@FirstName, @SecondName, @Number, @Email)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@FirstName", Firstname_txt.Text);
                    cmd.Parameters.AddWithValue("@SecondName", Secondname_txt.Text);
                    cmd.Parameters.AddWithValue("@Number", Number_txt.Text);
                    cmd.Parameters.AddWithValue("@Email", Email_txt.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrig();
                    MessageBox.Show("Seccessfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
