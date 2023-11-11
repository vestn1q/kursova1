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
  
    public partial class Form1 : Form
    {
        int endcef;
        int asd;
        DataSet ds;
      
    
        string tablename;
        Form2 examp = new Form2();

        public void LoadTable(string n)
        {

            DataSet ds;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            ds = new DataSet();
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM `{n}`", db.GetConnection());
            if (db.GetConnection().State == System.Data.ConnectionState.Open)
            {
                label5.Text = "Opened";
            }
            else
            {
                label5.Text = "Closed";

            }
            adapter.SelectCommand = command;
            adapter.Fill(table);
            adapter.Fill(ds);
            dg.DataSource = ds.Tables[0];
            tablename = n;
            asd = 1;
        }
        public void UpdateTable()
        {
            DataSet ds;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            ds = new DataSet();
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            string values;
            for (int t = 0; t < dg.RowCount-1; t++)
            {
                values = "'";
                for (int i = 0; i < dg.ColumnCount; i++)
                {
                    values += dg.Rows[t].Cells[i].Value.ToString();
                    values += "'";
                    if (i != dg.ColumnCount -1)
                    {
                        values += ", '";
                    }
                }
                MySqlCommand command_del = new MySqlCommand($"DELETE FROM {tablename} WHERE {tablename}.{tablename}_ID = {t+1}", db.GetConnection());
                MySqlCommand command_add = new MySqlCommand($"INSERT INTO {tablename} VALUES ({values})", db.GetConnection());
                adapter.SelectCommand = command_del;
                adapter.Fill(ds);
                adapter.SelectCommand = command_add;
                adapter.Fill(ds);

            }
        }
        public void Hand_input(string hand_input)
        {
            DataSet ds;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ds = new DataSet();
            DB db = new DB();
            db.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(hand_input, db.GetConnection());
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(table);
                adapter.Fill(ds);
                dg.DataSource = ds.Tables[0];
                asd = 1;
            }
            catch (Exception exc)
            {
                MessageBox.Show("ERROR:"+exc);
         
            }
           
        }
        public Form1(string hand_input)
        {
            InitializeComponent();
            if (hand_input != "")
            {
                Hand_input(hand_input);
            }
    


        }
        public void send_input(string hand_input)
        {
            Hand_input(hand_input);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
    


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
             
                
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
 
                LoadTable(cb_table.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            asd = 0;
            dg.ClearSelection();

            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
                return;

            var values = searchTextBox.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);


                for (int t = 0; t < dg.ColumnCount; t++)
                {
                for (int i = 0; i < dg.RowCount-1; i++)
                {
                    foreach (string value in values)
                    {
                        var row = dg.Rows[i];

                        if (row.Cells[t].Value.ToString().Contains(value))
                        {
                            row.Selected = true;
                        }
                    }

                }
            }
            asd = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
 

        }
     
            
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DB db = new DB();
            DialogResult result = MessageBox.Show(
                "Ви дійсно хочете видалити рядок даних?",
                "повідомлення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            string num;
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dg.SelectedRows)
                    {
                    num = row.Cells[0].Value.ToString();   
                    MySqlCommand command_del = new MySqlCommand($"DELETE FROM {tablename} WHERE {tablename}.{tablename}_ID = {num}", db.GetConnection());
                    dg.Rows.Remove(row);
                    adapter.SelectCommand = command_del;
                    adapter.Fill(ds);
                }
                }
                this.TopMost = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void dg_SelectionChanged(object sender, EventArgs e)
        {
            
            if (cb_table.Text=="product" && asd == 1)
            {
                
                
                try
                {
                    endcef = Int32.Parse(dg.SelectedRows[0].Cells[3].Value.ToString()) - Int32.Parse(dg.SelectedRows[0].Cells[4].Value.ToString());
                    textBox1.Text = dg.SelectedRows[0].Cells[3].Value.ToString() + " - "+ dg.SelectedRows[0].Cells[4].Value.ToString() + " = "+(endcef).ToString() + "%";
                    if (endcef > 0)
                    {
                        textBox1.Text += "\n Попит більше за пропозицію, при покупці прибуток збільшиться на " + endcef + "%";
                    }
                    if (endcef < 0)
                    {
                        textBox1.Text += "\n Попит менше за пропозицію, при подальщій покупці прибуток зменшиться на " + endcef + "%";
                    }
                    else
                    {
                        textBox1.Text += "\n Попит дорівнює пропозиції";
                    }
                    pictureBox1.Load($"C:\\Users\\vestn\\source\\repos\\Kursova\\files\\{dg.SelectedRows[0].Cells[0].Value.ToString()}.jpg");
                }
                catch (Exception)
                {
                }
     
            }
        }

        private void button2_Click_1(object sender, EventArgs e)

        {
            string indexnum = dg.SelectedRows[0].Cells[0].Value.ToString();
            InitializeComponent();
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                File.Copy(OPF.FileName, $"C:\\Users\\vestn\\source\\repos\\Kursova\\files\\{indexnum}.jpg", true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            examp.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

}
//INSERT INTO `product` VALUES ('3', 'cheese', '8,2', 'super sir crutoi aga');
//DELETE FROM product WHERE `product`.`PRODUCT_ID` = 5