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
    public partial class BoPhanQuanLy : Form
    {
        public BoPhanQuanLy()
        {
            InitializeComponent();
        }

        DataView dtvMonAn = new DataView();
        DataTable dsChiNhanh = new DataTable();
        DataTable dsMonAn = new DataTable();
        DataTable ThemMenu = new DataTable();
        private void BoPhanQuanLy_Load(object sender, EventArgs e)
        {
            cbDanhMuc.Items.Add("Tôm");
            cbDanhMuc.Items.Add("Cua");
            cbDanhMuc.Items.Add("Cá");
            cbDanhMuc.Items.Add("Nai");
            cbDanhMuc.Items.Add("Bầu");
            cbDanhMuc.Items.Add("Gà");

            cbDanhMuc2.Items.Add("Tôm");
            cbDanhMuc2.Items.Add("Cua");
            cbDanhMuc2.Items.Add("Cá");
            cbDanhMuc2.Items.Add("Nai");
            cbDanhMuc2.Items.Add("Bầu");
            cbDanhMuc2.Items.Add("Gà");

            cbChiNhanh.Items.Add("Tp.HCM");
            cbChiNhanh.Items.Add("Đồng Nai");
            cbChiNhanh.Items.Add("Đồng Sư Tử");

            dsMonAn.Columns.Add("Loai Mon An");
            dsMonAn.Columns.Add("Ten Mon An");
            dsMonAn.Columns.Add("Gia");

            dsChiNhanh.Columns.Add("Ten");
            dsChiNhanh.Columns.Add("Dia Chi");
            dsChiNhanh.Columns.Add("Lien He");
            dsChiNhanh.Columns.Add("So Luong Ban");

            ThemMenu.Columns.Add("Danh Muc Mon An");
            ThemMenu.Columns.Add("Ten Mon An");
            ThemMenu.Columns.Add("Ten Chi Nhanh");

            DataView dtvMonAn = new DataView(dsMonAn);
            dataviewChiNhanh.DataSource = dsChiNhanh;
            dataDSMonAn.DataSource = dtvMonAn;
            dataGridView2.DataSource = ThemMenu;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DataRow new1 = dsChiNhanh.NewRow();
            new1[0] = tbTenChiNhanh.Text;
            new1[1] = tbDiaChi.Text;
            new1[2] = tbLienHe.Text;
            new1[3] = SoLuongBan.Text;
            dsChiNhanh.Rows.Add(new1);
            //clear du lieu trong textbox
            tbTenChiNhanh.Clear();
            tbDiaChi.Clear();
            tbLienHe.Clear();
            SoLuongBan.Clear();
        }

        private void btThemMonAn_Click(object sender, EventArgs e)
        {
            DataRow new2 = dsMonAn.NewRow();
            new2[0] = cbDanhMuc.Text;
            new2[1] = tbTenMonAn.Text;
            new2[2] = tbGiaMonAn.Text;
            dsMonAn.Rows.Add(new2);
            //clear du lieu trong textbox
            tbTenMonAn.Clear();
            tbGiaMonAn.Clear();
        }

        private void cbDanhMuc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMonAn.Items.Clear();
            if (cbDanhMuc2.SelectedItem == "Tôm")
            {
                cbMonAn.Items.Add("Tôm Hùm");
                cbMonAn.Items.Add("Tôm Hổ");
                cbMonAn.Items.Add("Tôm Beo");
                cbMonAn.Items.Add("Tôm Cọp");
            }
            else if (cbDanhMuc2.SelectedItem == "Cá")
            {
                cbMonAn.Items.Add("Cá Mập");
                cbMonAn.Items.Add("Cá Hơi Mập");
                cbMonAn.Items.Add("Cá Ốm");
                cbMonAn.Items.Add("Cá Max Ốm");
            }
            else if (cbDanhMuc2.SelectedItem == "Cua")
            {
                cbMonAn.Items.Add("Cua Dá");
                cbMonAn.Items.Add("Cua Sắt");
                cbMonAn.Items.Add("Cua Nhôm");
                cbMonAn.Items.Add("Cua Nhựa");
            }
            else if (cbDanhMuc2.SelectedItem == "Gà")
            {
                cbMonAn.Items.Add("Gà Rút Thịt");
                cbMonAn.Items.Add("Gà Chiên Muối");
                cbMonAn.Items.Add("Gà Băm Nhuyễn");
            }
            else if (cbDanhMuc2.SelectedItem == "Bầu")
            {
                cbMonAn.Items.Add("Bầu Nướng");
                cbMonAn.Items.Add("Bầu Luộc");
                cbMonAn.Items.Add("Bầu Chiên Giòn");
            }
            else if (cbDanhMuc2.SelectedItem == "Nai")
            {
                cbMonAn.Items.Add("Nai Núi");
                cbMonAn.Items.Add("Nai Biển");
                cbMonAn.Items.Add("Nai Sao Hỏa");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow new3 = ThemMenu.NewRow();
            new3[0] = cbDanhMuc2.Text;
            new3[1] = cbMonAn.Text;
            new3[2] = cbChiNhanh.Text;
            ThemMenu.Rows.Add(new3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "")
            {
                dtvMonAn.RowFilter = "";
            }
            else
            {
          //      dtvMonAn.RowFilter = "Ten Mon An like '%" + tbTimKiem.Text + "%'";
            }
        }

        private void btXoaChiNhanh_Click(object sender, EventArgs e)
        {
            int RowIndex = dataviewChiNhanh.CurrentRow.Index;
            dataviewChiNhanh.Rows.RemoveAt(RowIndex);
        }

        private void btSuaChiNhanh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng hiện chưa có!", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btBaoCao_Click(object sender, EventArgs e)
        {
            BaoCao bc = new BaoCao();
            this.Hide();
            bc.ShowDialog();
            this.Show();
        }
    }
}

