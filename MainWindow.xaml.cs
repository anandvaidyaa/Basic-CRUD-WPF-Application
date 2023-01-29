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

namespace CRUD_Operations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewGrid();
        }

        SqlConnection connect = new SqlConnection("Data Source=ANAND\\SQLEXPRESS;Initial Catalog=CRUDDB;Integrated Security=True");
        public void ClearData()
        {
            name_txt.Clear();
            email_txt.Clear();
            phone_txt.Clear();
            myid_txt.Clear();
        }

        public void ViewGrid()
        {
            SqlCommand viewdata = new SqlCommand("select * from CrudTable",connect);
            DataTable mytab = new DataTable();
            connect.Open();
            SqlDataReader mysdr = viewdata.ExecuteReader();
            mytab.Load(mysdr);
            connect.Close();
            datagrid.ItemsSource = mytab.DefaultView;
        }
        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
        public bool CheckValid()
        {
            if(name_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is Required", "Failure",MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }
            if (email_txt.Text == string.Empty)
            {
                MessageBox.Show("Email is Required", "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (phone_txt.Text == string.Empty)
            {
                MessageBox.Show("Phone is Required", "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void insertbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckValid())
                {
                    SqlCommand ins = new SqlCommand("INSERT INTO CrudTable VALUES(@Name, @Email, @PhoneNo)", connect);
                    ins.CommandType = CommandType.Text;
                    ins.Parameters.AddWithValue("@Name", name_txt.Text);
                    ins.Parameters.AddWithValue("@Email", email_txt.Text);
                    ins.Parameters.AddWithValue("@PhoneNo", phone_txt.Text);
                    connect.Open();
                    ins.ExecuteNonQuery();
                    connect.Close();
                    ViewGrid();
                    MessageBox.Show("Sucessfully Added", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();

                }
            }
            catch(SqlException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            connect.Open();
            SqlCommand del = new SqlCommand("delete from CrudTable where ID = " + myid_txt.Text + " ", connect);
            try
            {
                del.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                connect.Close();
                ClearData();
                ViewGrid();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void updatebtn_Click(object sender, RoutedEventArgs e)
        {
            connect.Open();
            SqlCommand update = new SqlCommand("update CrudTable set Name = '" + name_txt.Text + "', Email = '" + email_txt.Text + "', PhoneNo = '" + phone_txt.Text + "'WHERE ID = '"+myid_txt.Text+"'",connect);
            try
            {
                update.ExecuteNonQuery();
                MessageBox.Show("Update Sucessfully","Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
                ClearData();
                ViewGrid();
            }
        }
    }
}
