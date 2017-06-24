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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

     
        private void button3_Click(object sender, EventArgs e)
        {if (lb_MBT.Text.Equals("") || lb_sbd.Text.Equals("")) { MessageBox.Show("Hãy nhập số báo danh và mã bài thi trước khi vào thi.", "Thông Báo"); }
            else
            {
               Program.MBT = lb_MBT.Text;
                Program.SBD= lb_sbd.Text;

                if (BLL.Start.isSBDtrue(Program.SBD,Program.MBT))
                {
                    Program.xacnhan = new XacNhan();
                    Program.xacnhan.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Thông tin sai.\n Xin mời nhập lại.", "Thông Báo");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuanLy QL = new QuanLy();
            QL.Show();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.onthib2 = new OnThiB2();
            Program.onthib2.Show();
            this.Hide();
        }
    }
}
