using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class HoatDongTongDai : Form
    {
        DataTable DonHang = new DataTable();
        DataTable Luu = new DataTable();

        public HoatDongTongDai()
        {
            InitializeComponent();
        }
        
        private void btGui_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng hiện chưa có!", "Thông Báo", MessageBoxButtons.OK);
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

        private void HoatDongTongDai_Load(object sender, EventArgs e)
        {
            cbChonChiNhanh.Items.Add("Tp.HCM");
            cbChonChiNhanh.Items.Add("Đồng Nai");
            cbChonChiNhanh.Items.Add("Đồng Sư Tử");

            cbChiNhanh2.Items.Add("Tp.HCM");
            cbChiNhanh2.Items.Add("Đồng Nai");
            cbChiNhanh2.Items.Add("Đồng Sư Tử");

            DonHang.Columns.Add("Mã Số Hóa Đơn");
            DonHang.Columns.Add("Tên Món Ăn");
            DonHang.Columns.Add("Số Lượng");
            DonHang.Columns.Add("Địa Chỉ");

            Luu.Columns.Add("Tên Khách Hàng");
            Luu.Columns.Add("Số Điện Thoại");
            Luu.Columns.Add("Địa Chỉ");
            Luu.Columns.Add("Email");

            dataDonHang.DataSource = DonHang;
            dataLuu.DataSource = Luu;
        }

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            DataRow new1 = DonHang.NewRow();
            new1[0] = tbMaSo.Text;
            new1[1] = tbTenMonAn.Text;
            new1[2] = tbSL.Text;
            new1[3] = tbDiaChi.Text;
            DonHang.Rows.Add(new1);
            //clear du lieu trong textbox
            tbMaSo.Clear();
            tbTenMonAn.Clear();
            tbSL.Clear();
            tbDiaChi.Clear();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            DataRow new2 = Luu.NewRow();
            new2[0] = tbTenKhachHang.Text;
            new2[1] = tbSDT.Text;
            new2[2] = tbDC.Text;
            new2[3] = tbEmail.Text;
            Luu.Rows.Add(new2);
            //clear du lieu trong textbox
            tbTenKhachHang.Clear();
            tbSDT.Clear();
            tbDC.Clear();
            tbEmail.Clear();
        }


    }
}