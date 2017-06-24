using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatHachB2
{
    public partial class XacNhan : Form
    {
        public XacNhan()
        {
            InitializeComponent();
        }

        private void XacNhan_Load(object sender, EventArgs e)
        {

            DTO.ThiSinh ts = new DTO.ThiSinh();
            ts=BLL.ThiSinh.ThongTinThiSinh(Program.SBD);
                lb_hovaten.Text = ts.Ho + " " + ts.Ten;
                lb_gioiTinh.Text = ts.GioiTinh;
                lb_QuocTich.Text = ts.QuocTich;
                lb_ngaysinh.Text = ts.NgaySinh;
                lb_diaChi.Text = ts.DiaChi;
            string filepath = @"imagets\" + ts.HinhAnh;
            try {pictureBox1.Image = Image.FromFile(filepath.ToString()); } catch {  filepath = @"imagets\avatar.png"; pictureBox1.Image = Image.FromFile(filepath.ToString()); }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL.ThiSinh.UpdateXN(rtb_phanHoi.Text, Program.SBD);
            Program.thi = new SatHachB2.Thi();
            Program.thi.Show();
            this.Hide();
        }

      
    }
}
