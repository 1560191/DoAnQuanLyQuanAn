using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanAn
{
    public partial class HoatDongTongDai : Form
    {
        DataTable DonHang = new DataTable();
        DataTable Luu = new DataTable();

        string connectinonST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        SqlConnection connection;
        SqlConnection connection2;
        SqlConnection connection3;
        SqlConnection connection4;
        SqlConnection connection5;
        SqlConnection connection6;
        SqlConnection connection7;
        SqlConnection connection8;
        SqlConnection connection9;
        SqlConnection connection10;
        SqlCommand command;
        SqlCommand command2;
        SqlCommand command3;
        SqlCommand command4;
        SqlCommand command5;
        SqlCommand command6;
        SqlCommand command7;
        SqlCommand command8;
        SqlCommand command9;
        SqlCommand command10;

        public HoatDongTongDai()
        {
            InitializeComponent();
        }

        private string Message2;

        public string Message21
        {
            get { return Message2; }
            set { Message2 = value; }
        }
        

        private void HoatDongTongDai_Load(object sender, EventArgs e)
        {
            lbname2.Text = Message2;

            connection = new SqlConnection(connectinonST);
            connection.Open();
            string query = "SELECT TenMonAn From MONAN";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable cbox = new DataTable();
            adapter.Fill(cbox);
            connection.Close();

            connection2 = new SqlConnection(connectinonST);
            connection2.Open();
            string query2 = "SELECT TenCN From CHI_NHANH";
            SqlCommand command2 = new SqlCommand(query2, connection2);
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            adapter2.SelectCommand = command2;

            DataTable cbchiNhanh = new DataTable();
            adapter2.Fill(cbchiNhanh);
            connection2.Close();

            connection7 = new SqlConnection(connectinonST);
            connection7.Open();
            string query7 = "SELECT TenCN From CHI_NHANH";
            SqlCommand command7 = new SqlCommand(query7, connection7);
            SqlDataAdapter adapter7 = new SqlDataAdapter();
            adapter7.SelectCommand = command7;

            DataTable cbchiNhanh2 = new DataTable();
            adapter7.Fill(cbchiNhanh2);
            connection7.Close();

            cbMonAn.DisplayMember = "TenMonAn";
            cbMonAn.ValueMember = "ID";
            cbMonAn.DataSource = cbox;

            cbChonChiNhanh.DisplayMember = "TenCN";
            cbChonChiNhanh.ValueMember = "ID";
            cbChonChiNhanh.DataSource = cbchiNhanh;

            cbChiNhanh2.DisplayMember = "TenCN";
            cbChiNhanh2.ValueMember = "ID";
            cbChiNhanh2.DataSource = cbchiNhanh2;

            dataDonHang.DataSource = DonHang;
            dataLuu.DataSource = Luu;
        }
        
        private void btGui_Click(object sender, EventArgs e)
        {
            connection8 = new SqlConnection(connectinonST);
            connection8.Open();

            string query8 = "exec Gui1 '"+cbMonAn.Text+"', '"+tbSL.Text+"'";
            SqlCommand command8 = new SqlCommand(query8, connection8);
           // command8.ExecuteNonQuery();
            MessageBox.Show("Đã Gửi Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            connection8.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int RowIndex = dataDonHang.CurrentRow.Index;
            dataDonHang.Rows.RemoveAt(RowIndex);
        }

        private void btGui2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            int RowIndex = dataDonHangWeb.CurrentRow.Index;
            dataDonHangWeb.Rows.RemoveAt(RowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            connection3 = new SqlConnection(connectinonST);
            connection3.Open();
                string query3 = "exec TaoDonHang_TongDai '" + cbMonAn.Text + "', '" + tbSL.Text + "', '" + tbDiaChi.Text + "', '" + cbChonChiNhanh.Text + "'";
                SqlCommand command3 = new SqlCommand(query3, connection3);
                command3.ExecuteNonQuery();
                MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                connection3.Close();

                connection4 = new SqlConnection(connectinonST);
                connection4.Open();
                string query4 = "SELECT TenMonAn, SoLuong, DiaChi From DONHANG_TONGDAI";
                SqlCommand command4 = new SqlCommand(query4, connection4);
                SqlDataAdapter adapter4 = new SqlDataAdapter();
                adapter4.SelectCommand = command4;
                DataTable DonHang = new DataTable();
                adapter4.Fill(DonHang);
                
                dataDonHang.DataSource = DonHang;
                tbSL.Clear();
                tbDiaChi.Clear();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            connection5 = new SqlConnection(connectinonST);
            connection5.Open();
            string query5 = "exec LuuKH '" + tbTenKhachHang.Text + "', '" + tbSDT.Text + "', '" + tbDC.Text + "', '" + tbMuaHang.Text + "'";
            SqlCommand command5 = new SqlCommand(query5, connection5);
            command5.ExecuteNonQuery();
            MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
            connection5.Close();

            connection6 = new SqlConnection(connectinonST);
            connection6.Open();
            string query6 = "SELECT TenKH, SDT, DiaChi, SoLanMuaHang From KHACHHANG";
            SqlCommand command6 = new SqlCommand(query6, connection6);
            SqlDataAdapter adapter6 = new SqlDataAdapter();
            adapter6.SelectCommand = command6;
            DataTable Luu = new DataTable();
            adapter6.Fill(Luu);

            dataLuu.DataSource = Luu;
        }


    }
}