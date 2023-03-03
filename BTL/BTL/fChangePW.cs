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
    public partial class fChangePW : Form
    {
        public fChangePW()
        {
            InitializeComponent();
        }

        private void formAccountProfile_Load(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        SqlConnection cn = new SqlConnection("Data Source=MSI\\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True");
        private void btnChangePW_Click(object sender, EventArgs e)
        {
            string tk = txtUserName.Text;
            string mk = txtPassWord.Text;
            string newpw = txtNewPassWord.Text;
            string typenpw = txtTypeNPW.Text;
            SqlDataAdapter da = new SqlDataAdapter("Select count (*) from Account where UserName =N'" + tk + "' and  PassWord = N'" + mk + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if(dt.Rows[0][0].ToString() == "1")
            {
                if(newpw == typenpw && newpw != "" && typenpw != "")
                {
                    //Đổi mật khẩu nếu đáp ứng điều kiện
                    SqlDataAdapter da1 = new SqlDataAdapter("update Account set PassWord = N'"+newpw+"'where UserName =N'"+tk+"' and PassWord =N'"+mk+"'",cn);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.Clear();
                }
                else //Th chưa nhập mà ấn nút và nhập lại mật khẩu mới sai
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNewPassWord, "Bạn chưa điền mật khẩu!");
                    errorProvider1.SetError(txtTypeNPW, "Mật khẩu nhập lại chưa đúng!");
                }
                
            }
            else //TH nhập sai tên người dùng và mật khẩu cũ
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtUserName, "Tên người dùng không đúng!");
                errorProvider1.SetError(txtPassWord, "Mật khẩu cũ không đúng!");
            }    
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
