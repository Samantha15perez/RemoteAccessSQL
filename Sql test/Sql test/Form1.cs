using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sql_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = null;
            SqlConnection cnn;
            connectionString = "Data Source=PL13\\MTCDB;Initial Catalog=Perez; User ID = sperez; Password = sperez18";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                label1.Text = "Connection Granted, Please enter a Query";
                cnn.Close();
            }
            catch(Exception ex)
            {
                label1.Text = "Connection Denied, please contact Network Provider";
            }
        }

        private void testQueryButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=PL13\\MTCDB;Initial Catalog=Perez; User ID = sperez; Password = sperez18";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            try
            {


                try
                {

                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter adp = new SqlDataAdapter();

                    cmd.Connection = cnn;
                    adp.SelectCommand = cmd;
                    cnn.Open();
                    cmd.CommandText = textBox1.Text;
                    adp.Fill(dt);

                    dataGridView1.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem parsing your query.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem connecting to the server.");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
