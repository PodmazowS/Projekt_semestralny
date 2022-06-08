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
            SqlCommand cmd = new SqlCommand("select * from Table2", con);
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
            Search_txt.Clear();
            NubmerCard_txt.Clear();
            RoomType_txt.Clear();
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
            if (NubmerCard_txt.Text == String.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (RoomType_txt.Text == String.Empty)
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Table2 VALUES (@FirstName, @SecondName, @Number, @Email, @CardNumber, @RoomType)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@FirstName", Firstname_txt.Text);
                    cmd.Parameters.AddWithValue("@SecondName", Secondname_txt.Text);
                    cmd.Parameters.AddWithValue("@Number", Number_txt.Text);
                    cmd.Parameters.AddWithValue("@Email", Email_txt.Text);
                    cmd.Parameters.AddWithValue("@CardNumber", NubmerCard_txt.Text);
                    cmd.Parameters.AddWithValue("@RoomType", RoomType_txt.Text);
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

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Table2 where ID = " + Search_txt.Text+ " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                LoadGrig();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not detected" +ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Table2 set FirstName = '" + Firstname_txt.Text+"' ,SecondName = '"+Secondname_txt.Text+"',Email = '"+Email_txt.Text+ "',  Number = '" + Number_txt.Text+ "',CardNumber = '" + NubmerCard_txt.Text + "', RoomType = '" +RoomType_txt.Text+"' WHERE ID = '" + Search_txt.Text+"' ",  con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been update successfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                clearData();
                LoadGrig();
                con.Close();
            }
        }
    }
}
