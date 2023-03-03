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
    public partial class fStatistics : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        string sql = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public fStatistics()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "select Statistic.nameKh as [Tên Khách Hàng],Statistic.sumBill as [Tổng Tiền],Statistic.ngaymua as [Ngày Mua Hàng] from Statistic";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           cn.Open();
            adapter = new SqlDataAdapter("select Statistic.nameKh as [Tên Khách Hàng],Statistic.sumBill as [Tổng Tiền],Statistic.ngaymua as [Ngày Mua Hàng] from Statistic where ngaymua between '" + dateTimePicker1.Value.ToString("yyyy/MM/dd")+"'and '"+dateTimePicker2.Value.ToString("yyyy/MM/dd")+ "'",cn);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"Statistic");
            dataGridView1.DataSource=ds.Tables["Statistic"];
            cn.Close();
        }

        private void fStatistics_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(sql);
            cn.Open();
            cn.Close();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Tính tổng doanh thu datagridview
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
            }
            richTextBox1.Text = sum.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
