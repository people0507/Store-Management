using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace BTL
{
    public class clsConnect 
    {
        SqlConnection con;
        string connect = @"Data Source=MSI\GF63;Initial Catalog=QuanliSanPhamSieuThi;Integrated Security=True";
        DataTable dt;

        public SqlConnection OpenConnect()
        {
            con = new SqlConnection(connect);
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
        public SqlConnection CloseConnect()
        {
            if(con.State == ConnectionState.Open)
                con.Close();
            return con;
        }
        //Hàm load dữ liệu
        public DataTable LoadData()
        {
            dt = new DataTable();
            OpenConnect();
            SqlCommand cmd = new SqlCommand("tbl_Products_LoadDL", con);
            cmd.CommandType = CommandType.StoredProcedure;//Viết stored;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            CloseConnect();
            return dt;
        }
        public DataTable Search(string ChuoiTimKiem)
        {
            OpenConnect();
            dt = new DataTable();
            SqlCommand cmd =new SqlCommand("tbl_Products_TimKiemSP", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("Sanpham",SqlDbType.NVarChar)).Value = ChuoiTimKiem;
            SqlDataAdapter da =new SqlDataAdapter(cmd);
            da.Fill(dt);
            CloseConnect();
            return dt;
        }
    }
}
