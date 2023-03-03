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
    public partial class fTbManager : Form
    {
        SqlConnection cn1;
        SqlCommand cmd1;
        string sql1 = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
        SqlDataAdapter adapter1 = new SqlDataAdapter();
        DataTable dt1 = new DataTable();

        public fTbManager()
        {
            InitializeComponent();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand("select Products.idPr as [ID SP],Products.name as [Name],Products.price as [Giá],Products.amount as [Số lượng]   from Products ", cn);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }
  
        public void LoadData()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand("select Products.idPr as [ID SP],Products.name as [Name],Products.price as [Giá],Products.amount as [Số lượng]   from Products ", cn);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fChangePW n = new fChangePW();
            this.Hide();
            n.ShowDialog();
            this.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void formTbManager_Load(object sender, EventArgs e)
        { 

            cn1 = new SqlConnection(sql1);
            cn1.Open();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Tính tổng của cột thành tiền
            int a = Convert.ToInt32(textBox3.Text);
            int b = Convert.ToInt32(textBox6.Text);
            int tong;
            tong = a * b;
            label5.Text = tong.ToString();
            //Thêm dữ liệu từ textbox vào trong listview
            ListViewItem lvi = new ListViewItem(textBox1.Text);
            lvi.SubItems.Add(textBox2.Text);
            lvi.SubItems.Add(textBox3.Text);
            lvi.SubItems.Add(textBox6.Text);
            lvi.SubItems.Add(label5.Text);
            listView1.Items.Add(lvi);
            
            //Giảm số lượng sản phẩm trong kho khi ấn thêm sản phẩm vào hóa đơn bằng câu lệnh truy vấn SQL
            int c = Convert.ToInt32(textBox4.Text);
            int d = Convert.ToInt32(textBox6.Text);
            int tong2 = 0;
            tong2 = c - d;
            textBox7.Text = tong2.ToString();

            cmd1 = cn1.CreateCommand();
            cmd1.CommandText = "UPDATE Products SET amount = '"+textBox7.Text+"' where idPr ='"+textBox1.Text+"'" ;
            cmd1.ExecuteNonQuery();
            LoadData();
            //Thêm thông tin sản phẩm đã chọn vào bảng hóa đơn
            cmd1 = cn1.CreateCommand();
            cmd1.CommandText = "INSERT INTO Bill4 (nameKH, namePr, price, amount, ngaymua) VALUES (N'" + textBox5.Text + "', N'" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "', CONVERT(DATETIME, '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', 102))";
            cmd1.ExecuteNonQuery();

        }
       
        private void displayMessageBox(object sender, CancelEventArgs e)
        {
            e.Cancel= true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Tính tổng tiền phải thanh toán
            DialogResult r;

            r = MessageBox.Show("Bạn có muốn thanh toán hóa đơn này!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,

            MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
            {
            }    
            else { 
                if(checkBox1.Checked == false)
                {
             double tong1 = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                tong1 += Convert.ToDouble(listView1.Items[i].SubItems[4].Text);
            }
            label7.Text = tong1.ToString();

            //Thêm thông tin người mua ngày mua và số tiền người dùng mua hàng ở siêu thị
            cmd1 = cn1.CreateCommand();
            cmd1.CommandText = "INSERT INTO Statistic (nameKH,sumBill,ngaymua) VALUES (N'" + textBox5.Text + "','" +label7.Text+ "', CONVERT(DATETIME, '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', 102))";
            cmd1.ExecuteNonQuery();
                }
                else
                {
                    
                    double tong1 = 0;
                    double tong2 = 0;
                    double a = Convert.ToDouble(numericUpDown1.Value);
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        tong1 += Convert.ToDouble(listView1.Items[i].SubItems[4].Text);
                    }
                    tong2 =tong1- (tong1 * a/100);
                    label7.Text = tong2.ToString();

                    //Thêm thông tin người mua ngày mua và số tiền người dùng mua hàng ở siêu thị
                    cmd1 = cn1.CreateCommand();
                    cmd1.CommandText = "INSERT INTO Statistic (nameKH,sumBill,ngaymua) VALUES (N'" + textBox5.Text + "','" + label7.Text + "', CONVERT(DATETIME, '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "', 102))";
                    cmd1.ExecuteNonQuery();
                }
            
            
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Cứ hiểu cái Sự kiện này để vẽ ra hóa đơn !
            e.Graphics.DrawString("*****$ Team 8 Supermarket $*****", new Font("Centuey Gothic", 30, FontStyle.Regular), Brushes.Black, new PointF(100, 15));
            e.Graphics.DrawString("ID", new Font("Centuey Gothic", 25, FontStyle.Regular), Brushes.Black, new PointF(10, 100));
            e.Graphics.DrawString("Sản Phẩm", new Font("Centuey Gothic", 25, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
            e.Graphics.DrawString("Giá SP", new Font("Centuey Gothic", 25, FontStyle.Regular), Brushes.Black, new PointF(300, 100));
            e.Graphics.DrawString("Số Lượng", new Font("Centuey Gothic", 25, FontStyle.Regular), Brushes.Black, new PointF(450, 100));
            e.Graphics.DrawString("Thành Tiền", new Font("Centuey Gothic", 25, FontStyle.Regular), Brushes.Black, new PointF(650, 100));
            e.Graphics.DrawString("----------------------------------------", new Font("Centuey Gothic", 30, FontStyle.Regular), Brushes.Black, new PointF(150, 850));
            e.Graphics.DrawString("Tổng Tiền Phải Trả: " + label7.Text, new Font("Centuey Gothic", 20, FontStyle.Regular), Brushes.Black, new PointF(50, 900));
            e.Graphics.DrawString("Tên Khách Hàng: " + textBox5.Text, new Font("Centuey Gothic", 20, FontStyle.Regular), Brushes.Black, new PointF(50, 950));
            e.Graphics.DrawString("Ngày Mua Hàng: " + dateTimePicker1.Text, new Font("Centuey Gothic", 20, FontStyle.Regular), Brushes.Black, new PointF(50, 1000));
            e.Graphics.DrawString("****** Cảm Ơn Quý Khách Đã Mua Hàng ******", new Font("Centuey Gothic", 20, FontStyle.Regular), Brushes.Black, new PointF(150, 1050));

            int lap = 0 ;
            int lap1 = 0;
            int lap2 = 0 ;
            int lap3 = 0;
            int lap4 = 0;
  
            for (int a = 0; a < listView1.Items.Count; a++)
            {
                {
                    e.Graphics.DrawString(listView1.Items[a].SubItems[0].Text , new Font("Arial Bold", 20), new SolidBrush(Color.Black), new PointF(20,200+lap));
                    lap = lap + 50;
                }
            }

            for (int b = 0; b < listView1.Items.Count; b++)
            {
                {
                    e.Graphics.DrawString(listView1.Items[b].SubItems[1].Text, new Font("Arial Bold", 20), new SolidBrush(Color.Black), new PointF(110,200+lap1));
                    lap1 = lap1 + 50;
                }
            }

            for (int c = 0; c < listView1.Items.Count; c++)
            {
                {
                    e.Graphics.DrawString(listView1.Items[c].SubItems[2].Text, new Font("Arial Bold", 20), new SolidBrush(Color.Black), new PointF(310,200+lap2));
                    lap2 = lap2 + 50;
                }
            }

            for (int d = 0; d < listView1.Items.Count; d++)
            {
                {
                    e.Graphics.DrawString(listView1.Items[d].SubItems[3].Text, new Font("Arial Bold", 20), new SolidBrush(Color.Black), new PointF(500, 200 + lap3));
                    lap3 = lap3 + 50;
                }
            }

            for (int f = 0; f < listView1.Items.Count; f++)
            {
                {
                    e.Graphics.DrawString(listView1.Items[f].SubItems[4].Text, new Font("Arial Bold", 20), new SolidBrush(Color.Black), new PointF(680, 200 + lap4));
                    lap4 = lap4 + 50;
                }
            }
        }
          

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
                //Xóa sản phẩm trong hóa đơn nếu khách đổi ý không mua
                int c = Convert.ToInt32(textBox7.Text);
                int d = Convert.ToInt32(textBox6.Text);
                int tong3 = 0;

                tong3 = c + d;
                textBox8.Text = tong3.ToString();

                cmd1 = cn1.CreateCommand();
                cmd1.CommandText = "UPDATE Products SET amount = '" + textBox8.Text + "' where idPr ='" + textBox1.Text + "'";
                cmd1.ExecuteNonQuery();
                LoadData();
                listView1.Items.Clear();

            
                cmd1 = cn1.CreateCommand();
            cmd1.CommandText = "DELETE FROM Bill4 where nameKH ='" + textBox5.Text + "'";
            cmd1.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           
            
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBilli4 k = new fBilli4();
            this.Hide();
            k.ShowDialog();
            this.Show();
        }

        private void thốngKêBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStatistics j = new fStatistics();
            this.Hide();
            j.ShowDialog();
            this.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(textBox6.Text.Trim().Length > 0 && !char.IsDigit(textBox6.Text, textBox6.Text.Length - 1))
            {
                errorProvider1.SetError(textBox6, "Không được nhập chữ!");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadData();
            listView1.Items.Clear();
            numericUpDown1.Value = 0;
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            label7.Text = "0đ";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

