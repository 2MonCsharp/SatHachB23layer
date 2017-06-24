using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatHachB2
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        //---Quản lý thí sinh-----------------
        String msts = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (openpic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openpic.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }

        private DTO.ThiSinh getData()
        {
            DTO.ThiSinh ts = new DTO.ThiSinh();
            ts.CMND = txtcmnd.Text;
            ts.DiaChi = rtxtdiachi.Text;
            if (rbtn_nam.Checked == true) ts.GioiTinh = "1"; else ts.GioiTinh = "0";
            ts.HinhAnh = pic_qltsdt.Name;
            ts.Ho = txt_Ho.Text;
            ts.MsThiSinh = txt_sbd.Text;
            ts.NgaySinh = datebirth.Text;
            ts.PhanHoi = "";
            ts.QuocTich = txt_quoctich.Text;
            ts.Ten = txt_ten.Text;
            return ts;
        }

        private void load_thisinh()
        {

            string cmd = "Select * from ThiSinh";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, Program.connStr);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            dataThiSinh.DataSource = ds;
        }
        private void quảnLýThíSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bc.Hide();
            load_thisinh();
            pn_qlThiSinh.Show();
            pn_qlThiSinh.BringToFront();
        }

        private void danhSáchCâuHỏiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bc.Hide();

            pn_qlcauhoi.BringToFront();
        }

        private void click_them(object sender, EventArgs e)
        {
            String namepic = openpic.SafeFileName;
            if (namepic.Equals("openFileDialog1")) namepic = "avatar.png";
            DTO.ThiSinh thisinh = new DTO.ThiSinh();
            thisinh = getData();
            int kq = BLL.ThiSinh.Add(thisinh);
            switch (kq)
            {
                case 1: { pic_add.Image = Image.FromFile(@"system picture\complete.png"); break; }
                case -1: { MessageBox.Show("Lỗi thêm thí sinh. Hãy kiểm tra kết nối với máy chủ", "Thông báo"); break; }
                case 0: { pic_add.Image = Image.FromFile(@"system picture\fail.png"); break; }
            }

            pic_add.Show();
            load_thisinh();

        }
        private void click_pic(object sender, System.EventArgs e)
        {
            Stream myStream = null;
            openpic = new OpenFileDialog();

            openpic.InitialDirectory = @"\";
            openpic.Filter = "txt files (*.jpg)|*.txt|All files (*.*)|*.*";
            openpic.FilterIndex = 2;
            openpic.RestoreDirectory = true;

            if (openpic.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openpic.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            pic_qltsdt.Image = Image.FromFile(openpic.FileName);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void dataThiSinh_SelectionChanged(object sender, EventArgs e)
        {

            if (dataThiSinh.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataThiSinh.SelectedCells[0].RowIndex;
                dataThiSinh.Rows[selectedrowindex].Selected = true;
                msts = dataThiSinh.SelectedRows[0].Cells["MsThiSinh"].Value.ToString();
                txt_Ho.Text = dataThiSinh.SelectedRows[0].Cells["Ho"].Value.ToString();
                txtcmnd.Text = dataThiSinh.SelectedRows[0].Cells["CMND"].Value.ToString();
                rtxtdiachi.Text = dataThiSinh.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                string i = dataThiSinh.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
                if (i.Equals("True")) rbtn_nam.Checked = true; else rbtn_nu.Checked = true;
                pic_qltsdt.Name = dataThiSinh.SelectedRows[0].Cells["HinhAnh"].Value.ToString();

                txt_sbd.Text = dataThiSinh.SelectedRows[0].Cells["MsThiSinh"].Value.ToString();
                datebirth.Text = dataThiSinh.SelectedRows[0].Cells["NgaySinh"].Value.ToString();

                txt_quoctich.Text = dataThiSinh.SelectedRows[0].Cells["QuocTich"].Value.ToString();
                txt_ten.Text = dataThiSinh.SelectedRows[0].Cells["Ten"].Value.ToString();
            }

            btnDel.Enabled = true;

        }
        private void QuanLy_Load(object sender, EventArgs e)
        {
          
            pic_edit.Hide();
            pic_del.Hide();
            pic_add.Hide();
            load_thisinh();
            cbb_searchBy.SelectedItem = "Tìm theo mã số";
            LoadChuDe();
            btnDel.Enabled = false;
            dgv_dscauhoi.DataSource = BLL.CauHoiNangCao.SelectAll();
            loadpaneQLNV();
        }

        private void Hide_nofication(object sender, KeyEventArgs e)
        {
            pic_edit.Hide();
            pic_del.Hide();
            pic_add.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtcmnd.Text = "";
            txt_Ho.Text = "";
            txt_quoctich.Text = "";
            txt_sbd.Text = "";
            txt_ten.Text = "";
            rtxtdiachi.Text = "";

            openpic.FileName = "openFileDialog1";



        }

        private void button3_Click(object sender, EventArgs e)
        {

            String namepic = openpic.SafeFileName;
            DTO.ThiSinh ts = new DTO.ThiSinh();
            ts = getData();
            if (namepic.Equals("openFileDialog1")) namepic = "avatar.png";
            switch (BLL.ThiSinh.Suathisinh(ts, msts))
            {
                case 1: { pic_edit.Image = Image.FromFile(@"system picture\complete.png"); break; }
                default: { pic_edit.Image = Image.FromFile(@"system picture\fail.png"); break; }
            }

            pic_edit.Show();
            load_thisinh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ThongTinThiSinh ts = new ThongTinThiSinh();
            if (ts.Xoathisinh(txt_sbd.Text))
            {

                pic_del.Image = Image.FromFile(@"system picture\complete.png");
            }
            else
            {
                pic_del.Image = Image.FromFile(@"system picture\fail.png");
            }
            pic_del.Show();
            load_thisinh();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataThiSinh.DataSource = BLL.ThiSinh.Find(txtkeyword.Text, cbb_searchBy.SelectedItem.Equals("Tìm theo mã số"));



        }




        private BaoCao bc = new BaoCao();
        private void danhSáchThíSinhDựThiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bc.MdiParent = this;

            bc.Show();
            bc.BringToFront();
            pn_qlcauhoi.Hide();
            pn_qlThiSinh.Hide();
            pn_qlNv.Hide();


        }


        //-------------Panel Quản lý câu hỏi
        private void loadpnelqlcauhoi()
        {
            dgv_dscauhoi.DataSource = BLL.CauHoiNangCao.SelectAll();
        }

        private void load_grvByChange(object sender, EventArgs e)
        {
            dgv_dscauhoi.DataSource = BLL.CauHoiNangCao.DanhSachCauHoiByChuDe(cbb_searchQuestionbyme.SelectedValue.ToString());

        }
        private void LoadChuDe()
        {
            cbb_searchQuestionbyme.DataSource = BLL.CauHoiNangCao.DanhSachChuDe();
            cbb_Chude.DataSource = BLL.CauHoiNangCao.DanhSachChuDe();
            cbb_searchQuestionbyme.ValueMember = "MsChuDe";
            cbb_searchQuestionbyme.DisplayMember = "TenChuDe";
            cbb_Chude.ValueMember = "MsChuDe";
            cbb_Chude.DisplayMember = "TenChuDe";

        }

        private void managerQsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            pn_qlcauhoi.Show();
            pn_qlThiSinh.Hide();

        }
        private void AddQuestion()
        {

            int countDA = 2;
            if (rtb_DA3.TextLength > 0) { if (rtb_DA4.TextLength > 0) countDA = 4; else countDA = 3; }

            if (countDA == 2)
            {
                DTO.CauHoi2DA ch = new DTO.CauHoi2DA();
                ch.Cauhoi = rtb_cauHoi.Text;
                ch.DapAn1 = rtb_DA1.Text;
                ch.DapAn2 = rtb_DA2.Text;
                if (cb_DA1.Checked) { ch.DA1right = "1"; } else { ch.DA1right = "0"; }
                if (cb_DA2.Checked) { ch.DA2right = "1"; } else { ch.DA1right = "0"; }
                ch.MsChuDe = cbb_Chude.SelectedValue.ToString();
                BLL.CauHoiNangCao.AddQuestion2DA(ch);
            }
            if (countDA == 3)
            {
                DTO.CauHoi3DA ch = new DTO.CauHoi3DA();
                ch.Cauhoi = rtb_cauHoi.Text;
                ch.DapAn1 = rtb_DA1.Text;
                ch.DapAn2 = rtb_DA2.Text;
                ch.DapAn3 = rtb_DA3.Text;
                if (cb_DA1.Checked) { ch.DA1right = "1"; } else { ch.DA1right = "0"; }
                if (cb_DA2.Checked) { ch.DA2right = "1"; } else { ch.DA2right = "0"; }
                if (cb_DA3.Checked) { ch.DA3right = "1"; } else { ch.DA3right = "0"; }
                ch.MsChuDe = cbb_Chude.SelectedValue.ToString();
                BLL.CauHoiNangCao.AddQuestion2DA(ch);
            }
            if (countDA == 4)
            {
                DTO.CauHoi4DA ch = new DTO.CauHoi4DA();
                ch.Cauhoi = rtb_cauHoi.Text;
                ch.DapAn1 = rtb_DA1.Text;
                ch.DapAn2 = rtb_DA2.Text;
                ch.DapAn3 = rtb_DA3.Text;
                ch.DapAn4 = rtb_DA4.Text;
                if (cb_DA4.Checked) { ch.DA4right = "1"; } else { ch.DA4right = "0"; }
                if (cb_DA3.Checked) { ch.DA3right = "1"; } else { ch.DA3right = "0"; }
                if (cb_DA1.Checked) { ch.DA1right = "1"; } else { ch.DA1right = "0"; }
                if (cb_DA2.Checked) { ch.DA2right = "1"; } else { ch.DA2right = "0"; }
                ch.MsChuDe = cbb_Chude.SelectedValue.ToString();
                BLL.CauHoiNangCao.AddQuestion4DA(ch);
            }



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (rtb_cauHoi.TextLength == 0)
            {
                MessageBox.Show("Chưa nhập câu hỏi", "Thông báo");
            }
            else if (rtb_DA2.TextLength == 0)
            {
                MessageBox.Show("Chưa nhập đáp án", "Thông báo");
            }
            else if (cb_DA1.Checked || cb_DA2.Checked || cb_DA3.Checked || cb_DA4.Checked)
            {
                AddQuestion();
                dgv_dscauhoi.DataSource = BLL.CauHoiNangCao.SelectAll();
                for (int i = 0; i < dgv_dscauhoi.Rows.Count; i++)
                {
                    dgv_dscauhoi.Rows[i].Cells[0].Value = i + 1;
                }
            }
            else { MessageBox.Show("Chưa tích vào đáp án chính xác", "Thông báo"); }

        }

        private void Check_rtb2(object sender, KeyEventArgs e)
        {
            if (rtb_DA1.TextLength == 0)
            {
                MessageBox.Show("Chưa có đáp án 1", "Thông báo");
                rtb_DA2.Text = "";
            }
        }

        private void Check_rtb3(object sender, KeyEventArgs e)
        {
            if (rtb_DA1.TextLength == 0 && rtb_DA2.TextLength == 0)
            {
                MessageBox.Show("Chưa có đáp án 1 và 2", "Thông báo");
                rtb_DA3.Text = "";
            }
            else
            {
                if (rtb_DA1.TextLength == 0) MessageBox.Show("Chưa có đáp án 1", "Thông báo");
                if (rtb_DA2.TextLength == 0) MessageBox.Show("Chưa có đáp án 2", "Thông báo");
                rtb_DA3.Text = "";
            }

            
        }

        private void Check_rtb4(object sender, KeyEventArgs e)
        {
            if (rtb_DA1.TextLength == 0 || rtb_DA2.TextLength == 0 || rtb_DA3.TextLength == 0)
            {
                MessageBox.Show("Chưa có đáp án ở các ô đầu tiên", "Thông báo");
                rtb_DA4.Text = "";
            }
        }

        private void check_cb1(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Tag.ToString())
            {
                case "1":
                    {
                        if (rtb_DA1.TextLength == 0)
                        {
                            MessageBox.Show("Chưa có đáp án ở ô này", "Thông báo");
                            cb_DA1.Checked = false;
                        }
                        break;
                    }
                case "2":
                    {
                        if (rtb_DA2.TextLength == 0)
                        {
                            MessageBox.Show("Chưa có đáp án ở ô này", "Thông báo");
                            cb_DA2.Checked = false;
                        }
                        break;
                    }
                case "3":
                    {
                        if (rtb_DA3.TextLength == 0)
                        {
                            MessageBox.Show("Chưa có đáp án ở ô này", "Thông báo");
                            cb_DA3.Checked = false;
                        }
                        break;
                    }
                case "4":
                    {
                        if (rtb_DA4.TextLength == 0)
                        {
                            MessageBox.Show("Chưa có đáp án ở ô này", "Thông báo");
                            cb_DA4.Checked = false;
                        }
                        break;
                    }
            }

        }
        //--------------------------Panel Quản lý nhân viên
        private DTO.NhanVien getDataNV()
        {
            DTO.NhanVien nv = new DTO.NhanVien();
            nv.ChucVu = cbb_ChucVu.SelectedValue.ToString();
            nv.Diachi = rtb_DiachiNv.Text;
            nv.GioiTinh = "0";
            if (rdo_btn_nam.Checked) nv.GioiTinh = "1";
            nv.Ho = txt_Honv.Text;
            nv.Ten = txt_TenNV.Text;
            nv.MaNV = txt_MaNV.Text;
            nv.NgaySinh = NgaySinhNV.Text;
            nv.SoDienThoai = txt_SDTNV.Text;
            return nv;

        }
        private void button8_Click(object sender, EventArgs e)
        {
            DTO.NhanVien nv = new DTO.NhanVien();
            nv = getDataNV();
            if (BLL.NhanVien.Insert(nv) != 1) { pic_addNv.Image = Image.FromFile(@"system picture\fail.png"); }
            pic_addNv.Show();

        }
        private void load_cbbChucVu()
        {
            cbb_ChucVu.DataSource = BLL.NhanVien.SelecAllCV();
            cbb_ChucVu.DisplayMember = "TenCV";
            cbb_ChucVu.ValueMember = "MCV";
        }
        private void hideNotif()
        {
            pic_addNv.Hide();
            pic_deleleNV.Hide();
            pic_saveChangeNV.Hide();
            pic_saveChangeNV.Image = Image.FromFile(@"system picture\complete.png");
            pic_deleleNV.Image = Image.FromFile(@"system picture\complete.png");
            pic_addNv.Image = Image.FromFile(@"system picture\complete.png");

        }
        private void loadpaneQLNV()
        {
            hideNotif();
            load_cbbChucVu();
            load_cbbChucVu();
            dgv_nvien.DataSource = BLL.NhanVien.SelecAllNhanVien();
            for (int i = 0; i < dgv_nvien.Rows.Count; i++)
            {
                dgv_nvien.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btn_saveChangenv_Click(object sender, EventArgs e)
        {
            DTO.NhanVien nv = new DTO.NhanVien();
            nv = getDataNV();
            if (BLL.NhanVien.Update(nv) != 1) { pic_saveChangeNV.Image = Image.FromFile(@"system picture\fail.png"); }
            pic_saveChangeNV.Show();
        }

        private void dgrNV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_nvien.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgv_nvien.SelectedCells[0].RowIndex;
                dgv_nvien.Rows[selectedrowindex].Selected = true;
                txt_MaNV.Text = dgv_nvien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                txt_Honv.Text = dgv_nvien.SelectedRows[0].Cells["Ho"].Value.ToString();
                txt_TenNV.Text = dgv_nvien.SelectedRows[0].Cells["Ten"].Value.ToString();
                rdo_btn_nam.Checked = true;
                if (dgv_nvien.SelectedRows[0].Cells["GioiTinh"].Value.ToString() == "False")
                {
                    rbt_gt_nu.Checked = true;
                }
                NgaySinhNV.Text = dgv_nvien.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
                rtb_DiachiNv.Text = dgv_nvien.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                cbb_ChucVu.SelectedValue = dgv_nvien.SelectedRows[0].Cells["ChucVu"].Value.ToString();
                txt_SDTNV.Text = dgv_nvien.SelectedRows[0].Cells["Sdt"].Value.ToString();
            }

            btn_saveChangenv.Enabled = true;
            btn_xoanv.Enabled = true;
        }

        private void addQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bc.Hide();
            loadpaneQLNV();
            pn_qlNv.Show();
            pn_qlNv.BringToFront();
        }

        private void Even_keydowNVpanel(object sender, KeyEventArgs e)
        {
            hideNotif();
        }

        private void btn_xoanv_Click(object sender, EventArgs e)
        {
            if (BLL.NhanVien.Delete(txt_MaNV.Text) != 1)
            {
                pic_deleleNV.Image = Image.FromFile(@"system picture\fail.png");
            }
            pic_deleleNV.Show();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_MaNV.Text = "";
            txt_Honv.Text = "";
            txt_TenNV.Text = "";
            rbt_gt_nu.Checked = false;

            NgaySinhNV.Text = "1/1/1990";
            rtb_DiachiNv.Text = "";
            cbb_ChucVu.SelectedValue = "NV3";
            txt_SDTNV.Text = "";
        }
    }
}
