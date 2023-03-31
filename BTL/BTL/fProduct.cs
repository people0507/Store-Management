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
    public partial class fProduct : Form
    {   //Kết nối SQL !
        SqlConnection cn;
        SqlCommand cmd;
        string sql = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public fProduct()
        {
            InitializeComponent();
        }
        //Tạo hàm LoadData để sử dụng mỗi khi muốn load lại dữ liệu sẽ gọi đến nó !
        public void loadData()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "select Products.idPr as [ID SP],Products.name as [Tên Sản Phẩm],Products.id as [ID DM],Products.price as [Giá SP],Products.amount as [Số Lượng SP] FROM Products";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Sự kiện khi ấn vào mỗi một ô trong datagridview sẽ hiện tương ứng trong textbox!
            int i = dataGridView2.CurrentRow.Index;
            txtIDSP.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            txtNameSP.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
            txtprice.Text = dataGridView2.Rows[i].Cells[3].Value.ToString();
            txtAmount.Text = dataGridView2.Rows[i].Cells[4].Value.ToString();
            txtIDDM.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
        }

        private void fProduct_Load(object sender, EventArgs e)
        {
            //Mở kết nối mỗi lần load form!
            cn = new SqlConnection(sql);
            cn.Open();
            loadData();
            cn.Close();


        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            //Thêm thông tin về sản phẩm!
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Products (idPr, name,id, price, amount) VALUES('" + txtIDSP.Text + "', N'" + txtNameSP.Text + "','" + txtIDDM.Text + "','" + txtprice.Text + "','" + txtAmount.Text + "')";
            cmd.ExecuteNonQuery();
            loadData();
            cn.Close();

        }
        //Xóa sản phẩm!
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Products where idPr = '" + txtIDSP.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
            
        }
        //Xửa sản phẩm!
        private void btnEdit1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = " UPDATE Products SET  name = N'" + txtNameSP.Text + "', id ='" + txtIDDM.Text + "', price = '" + txtprice.Text + "', amount = '" + txtAmount.Text + "' where idPr='" + txtIDSP.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
            cn.Close();


        }

        private void btnLoad1_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtIDSP.Clear();
            txtNameSP.Clear();
            txtprice.Clear();
            txtAmount.Clear();
            txtIDDM.Clear();
            cn.Open();
            loadData();
            cn.Close();
        }
        //Tìm kiếm sản phẩm bằng tên
        private void btnSearch_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = "select Products.idPr as [ID SP],Products.name as [Tên Sản Phẩm],Products.id as [ID DM],Products.price as [Giá SP],Products.amount as [Số Lượng SP] FROM Products where  Products.name like N'%" + txtSearch.Text + "%'";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
