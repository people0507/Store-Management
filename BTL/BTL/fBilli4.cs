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
    public partial class fBilli4 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        string sql = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public fBilli4()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(sql);
            cn.Open(); 
           LoadData();
            cn.Close();
        }

        public void LoadData()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "select Bill4.idBill as [ID Hóa Đơn],Bill4.nameKH as [Tên Khách Hàng],Bill4.namePr as [Tên Sản Phẩm],Bill4.price as [Giá SP],Bill4.amount as [Số lượng SP],Bill4.ngaymua as [Ngày mua hàng] from Bill4";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        
        }


        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandText = "Select Bill4.idBill as [ID Hóa Đơn],Bill4.nameKH as [Tên Khách Hàng],Bill4.namePr as [Tên Sản Phẩm],Bill4.price as [Giá SP],Bill4.amount as [Số lượng SP],Bill4.ngaymua as [Ngày mua hàng] from Bill4 where  nameKH like  N'" + textBox6.Text + "';";
                adapter.SelectCommand = cmd;
                dt.Clear();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                cn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
