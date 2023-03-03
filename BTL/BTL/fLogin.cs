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
    public partial class fLogin : Form
    {

        public fLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát phần mềm quản lý ? ", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Kết nối với SQL
            SqlConnection cn = new SqlConnection("Data Source=MSI\\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True");
            SqlConnection cn1 = new SqlConnection("Data Source=MSI\\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True");
            //Xử lý ngoại lệ  bằng try/catch
            try
            {
                cn.Open();
                string tk = textBox1.Text;
                string mk = textBox2.Text;
                string role = textBox3.Text;
                string sql = "select * from Account where UserName='" + tk + "' and PassWord='" + mk + "' and Role ='" + role + "'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                
                cn1.Open();
                string sql1 = "select * from Account where UserName='" + tk + "' and PassWord='" + mk + "' and Role ='" + role + "'";
                SqlCommand cmd1 = new SqlCommand(sql, cn1);
                SqlDataReader dr1 = cmd1.ExecuteReader();

            //Sử dụng SqlDataReader trả về giá trị true or false để check tk mk và role đúng or sai
                if (dr.Read() == true && role == "admin")//Cấp quyền admin
                {
                    MessageBox.Show("Đăng nhập thành công.");
                    fAdmin f = new fAdmin();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                

                if (dr1.Read() == true && role == "staff")//Cấp quyền nhân viên
                {
                    MessageBox.Show("Đăng nhập thành công.");
                    fTbManager n = new fTbManager();
                    this.Hide();
                    n.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "staff";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "admin";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
