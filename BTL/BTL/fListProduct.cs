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

namespace BTL
{
    public partial class fListProduct : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        string sql = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public fListProduct()
        {
            InitializeComponent();
        }
        
        public void loadData()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "Select * from ListOfProduct";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void fListProduct_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(sql);
            cn.Open();
            loadData();

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO ListOfProduct (id,name) VALUES ('" + textBox2.Text + "', N'" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE ListOfProduct SET id ='" + textBox2.Text + "', name = N'" + textBox3.Text + "' where id ='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM ListOfProduct WHERE id = '" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }
    }
}
