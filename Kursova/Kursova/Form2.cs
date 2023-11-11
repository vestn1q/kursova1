using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kursova
{
    
    public partial class Form2 : Form
    {
        
        string hand_input;
        int asd;
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        public Form2()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DB db = new DB();
            try
            {
                hand_input = textBox1.Text;
                this.Hide();
                new Form1(hand_input).Show();
               
            }
            catch (SqlException odbcEx)
            {        
            }
           
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Form1("").Show();
        }
    }
}
