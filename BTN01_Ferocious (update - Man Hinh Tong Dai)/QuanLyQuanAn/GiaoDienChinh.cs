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
    public partial class GiaoDienChinh : Form
    {
        DataView dtvMonAn = new DataView();
        DataTable dsBanAn = new DataTable();
        DataTable dsMonAn = new DataTable();
        DataTable dsHoaDon = new DataTable();
        string connectinonST = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanAn;Integrated Security=True";
        SqlConnection connection;
        SqlConnection connection2;
        SqlConnection connection3;
        SqlConnection connection4;
        SqlCommand command;
        SqlCommand command2;
        SqlCommand command3;
        SqlCommand command4;
        public GiaoDienChinh()
        {
            InitializeComponent();
            LoadTable();
        }

        void LoadTable()
        {
            List<Table> tablelist = LoadTablelist();
            //với mỗi table nằm trong tablelist chúng ta tạo 1 button để hiển thị bàn ăn
            foreach (Table item in tablelist)
            {
                Button bt = new Button()
                {
                    Width = 70,
                    Height = 70
                };
                bt.Text = item.TenBan + Environment.NewLine /*xuong dong*/ + item.TinhTrang;
                switch (item.TinhTrang)
                {
                    case "Trống":
                        bt.BackColor = Color.White;
                        break;
                    default:
                        bt.BackColor = Color.Aqua;
                        break;
                }
                dsachBanAn.Controls.Add(bt);
            }
        }

        public List<Table> LoadTablelist()
        {
            List<Table> tablelst = new List<Table>();
            connection = new SqlConnection(connectinonST);
            connection.Open();
            string query = "SELECT * FROM BAN_AN";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            //đổ dữ liệu từ csdl vào dsBanAn
            DataTable dsBanAn = new DataTable();
            adapter.Fill(dsBanAn);
            //cho mỗi dataRow trong dsBanAn chúng ta lấy ra từng dòng
            foreach (DataRow item in dsBanAn.Rows)
            {
                Table table = new Table(item);
                tablelst.Add(table);
            }
            return tablelst;
        }
        //Lấy tên người đăng nhập
        private string Message;
        public string Message1
        {
          get { return Message; }
          set { Message = value; }
        }

        

        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            TenHienThi.Text = Message;
            
            connection = new SqlConnection(connectinonST);
            connection.Open();
            string query = "SELECT TenMonAn, DonGia, SoLuongTrongKho FROM MONAN";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable dsMonAn = new DataTable();
            adapter.Fill(dsMonAn);
            connection.Close();

            dataDSThucDon.DataSource = dsMonAn;
            dataThongTinHoaDon.DataSource = dsHoaDon;
            binding();
            
        }

        private void btQuanLyQuanAn_Click(object sender, EventArgs e)
        {
            BoPhanQuanLy ql = new BoPhanQuanLy();
            this.Hide();
            ql.ShowDialog();
            this.Show();
        }

        private void btTongDai_Click(object sender, EventArgs e)
        {
            HoatDongTongDai td = new HoatDongTongDai();
            this.Hide();
            td.ShowDialog();
            this.Show();
        }

        //hàm tính tổng thu khi đã giảm giá
        private double phanthu(double a, double b)
        {
            double x;
            x = a * (b / 100);
            return x;
        }

        private void btPhanThu_Click(object sender, EventArgs e)
        {
            double a = double.Parse(tbTongGia.Text);
            double b = double.Parse(tbGiamGia.Text);
            double x = phanthu(a, b);
            tbPhanThu.Text = x.ToString();
        }

        private void btInXuongBep_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Hiện Chưa Có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btNhanHoaDon_Click(object sender, EventArgs e)
        {
            XuatHoaDon();
        }

        //lay du lieu tu dataTable vao textbox
        public void binding()
        {
            tbDichVu.DataBindings.Clear();
            tbDichVu.DataBindings.Add("text", dataDSThucDon.DataSource, "TenMonAn");
            tbDonGia.DataBindings.Clear();
            tbDonGia.DataBindings.Add("text", dataDSThucDon.DataSource, "DonGia");
        }


        private void tbDichVu_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void btCapNhap_Click(object sender, EventArgs e)
        {
            connection2 = new SqlConnection(connectinonST);
            connection2.Open();

            string query2 = "exec Gui1 '" + tbDichVu.Text + "', '" + tbSoLuong.Text + "'";
            SqlCommand command2 = new SqlCommand(query2, connection2);
            //command2.ExecuteNonQuery();
            MessageBox.Show("Đã Thêm Thành Công!","Thông Báo",MessageBoxButtons.OK);
            connection2.Close();
            XuatHoaDon();
        }
        private void XuatHoaDon()
        {
            connection3 = new SqlConnection(connectinonST);
            connection3.Open();
            string query3 = "SELECT iHD.TenMonAn, iHD.DonGia, iHD.SoLuong FROM info_HOADON iHD, HOADON HD WHERE iHD.IDHoaDon = HD.ID";
            SqlCommand command3 = new SqlCommand(query3, connection3);
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            adapter3.SelectCommand = command3;

            DataTable dsHoaDon = new DataTable();
            adapter3.Fill(dsHoaDon);
            dataThongTinHoaDon.DataSource = dsHoaDon;
            connection3.Close();
        }
    }
}
