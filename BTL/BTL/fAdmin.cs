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
    public partial class fAdmin : Form
    {
        //Kết nối SQL !
        SqlConnection cn;
        SqlCommand cmd;
        string sql = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        //Tạo hàm LoadData để sử dụng mỗi khi muốn load lại dữ liệu sẽ gọi đến nó !
        public void loadData()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "SELECT ROW_NUMBER() OVER(ORDER BY Account.UserName) as STT, Account.name as 'Họ tên', Account.UserName as 'Tên đăng nhập',Account.PassWord as 'Mật khẩu',Account.Sex as 'Giới tính', Account.Birth as 'Ngày sinh', Account.Born as 'Quê quán', Account.Role as 'Quyền',Account.Contact as 'SĐT' FROM Account";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public fAdmin()
        {
            InitializeComponent();
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            //Mở kết nối mỗi lần load form!
            cn = new SqlConnection(sql);
            cn.Open();
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Check giới tính của nhân viên !
            string insert_gender;
            if (rbMale.Checked)
            {
                insert_gender = "Nam";
            }
            else { 
                insert_gender = "Nữ";
            }
            //Thêm các thông tin của nhân viên bằng câu lệnh truy vấn sql!
            cmd = cn.CreateCommand();
            cmd.CommandText = "INSERT INTO Account (UserName,Name,PassWord,Role,Born,Sex,Birth,Contact) VALUES ('" + txtAcc.Text + "' , N'" + txtName.Text + "' , '" + txtPW.Text + "' , N'" + txtRole.Text + "' , N'" + txtHT.Text +"',N'" + insert_gender + "','" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "','"+txtContact.Text+"')";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Check giới tính của nhân viên !
            string insert_gender;
            if (rbMale.Checked) insert_gender = "Nam";
            else insert_gender = "Nữ";
            //Sửa thông tin của nhân viên bằng câu lệnh truy vấn sql!
            cmd = cn.CreateCommand();
            cmd.CommandText = "UPDATE Account SET UserName = N'" + txtAcc.Text + "', Name = N'" + txtName.Text + "', PassWord = N'" + txtPW.Text + "', Role = N'" + txtRole.Text + "', Born = N'" + txtHT.Text + "', Sex = N'" + insert_gender + "', Birth ='"+ dateTimePicker1.Value.ToString("yyyy/MM/dd")+"',Contact ='"+txtContact.Text+"' WHERE Username = '" + txtAcc.Text +"'";
            cmd.ExecuteNonQuery();
            loadData();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Sự kiện khi ấn vào mỗi một ô trong datagridview sẽ hiện tương ứng trong textbox!
            int i = dataGridView1.CurrentRow.Index;
            txtName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtAcc.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtPW.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtHT.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtRole.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtContact.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "Nam") rbMale.Checked = true;
            else rbFemale.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            rs = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Xóa thông tin nhân viên!
            cmd = cn.CreateCommand();
            cmd.CommandText = "DELETE FROM Account WHERE UserName = '" + txtAcc.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(sql);
            cn.Open();
            loadData();
            txtName.Clear();
            txtRole.Clear();
            txtHT.Clear();
            txtContact.Clear();
            txtAcc.Clear();
            txtPW.Clear();
            rbFemale.Checked = false;
            rbMale.Checked = false;
        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nối sang form khác!
            fTbManager n = new fTbManager();
           
            n.ShowDialog();
            
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nối sang form khác!
            fListProduct a = new fListProduct();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nối sang form khác!
            fProduct b = new fProduct();
            this.Hide();
            b.ShowDialog();
            this.Show();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            //Sự kiến bắt lỗi để trống!
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Không được để trống tên !");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAcc_Leave(object sender, EventArgs e)
        {
            //Sự kiến bắt lỗi để trống!
            if (txtAcc.Text == "")
            {
                errorProvider1.SetError(txtAcc, "Không được để trống tài khoản!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtPW_Leave(object sender, EventArgs e)
        {
            //Sự kiến bắt lỗi để trống!
            if (txtPW.Text == "")
            {
                errorProvider1.SetError(txtPW, "Không được để trống mật khẩu!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtHT_Leave(object sender, EventArgs e)
        {
            //Sự kiến bắt lỗi để trống!
            if (txtHT.Text == "")
            {
                errorProvider1.SetError(txtHT, "Không được để trống quê quán!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtRole_Leave(object sender, EventArgs e)
        {
            //Sự kiến bắt lỗi để trống!
            if (txtRole.Text == "")
            {
                errorProvider1.SetError(txtRole, "Không được để trống quyền!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtContact_TextChanged_1(object sender, EventArgs e)
        {//Sự kiện bắt lỗi không được nhập chữ!
            Control ctr = (Control)sender;

            if (ctr.Text.Trim().Length > 0 && !char.IsDigit(ctr.Text, ctr.Text.Length - 1))

                this.errorProvider1.SetError(txtContact, "Hãy nhập chữ số!");

            else

                this.errorProvider1.Clear();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtHT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
