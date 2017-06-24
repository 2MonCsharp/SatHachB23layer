using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatHachB2
{
    class ThongTinThiSinh
    {



  
        
        
        public bool Xoathisinh(string sbd)
        {
         
            string cmd = "EXEC XoaThiSinh '" + sbd + "'";
            SqlConnection dbConn = new SqlConnection(Program.connStr);
            try
            {
                dbConn.Open();

            }
            catch
            {
                MessageBox.Show("Lỗi xóa thí sinh. Hãy kiểm tra kết nối với máy chủ", "Thông báo");

                return false;
            }
            SqlCommand dbCmd = new SqlCommand(cmd, dbConn);
            try
            {
                dbCmd.ExecuteNonQuery();
                dbConn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        
            

        }
        public bool Timkiem(string key)
        {

            string cmd = "EXEC Timkiem '" + key + "'";
            SqlConnection dbConn = new SqlConnection(Program.connStr);
            try
            {
                dbConn.Open();

            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm thí sinh. Hãy kiểm tra kết nối với máy chủ", "Thông báo");

                return false;
            }
            SqlCommand dbCmd = new SqlCommand(cmd, dbConn);
            try
            {
                dbCmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            dbConn.Close();
            return true;

        }


        public string ho { get; set; }
        public string ten { get; set; }
        public string gioiTinh { get; set; }
        public string ngaysinh { get; set; }
        public string quoctich { get; set; }
        public string cmnd { get; set; }
        public string diachi { get; set; }
        public string hinhanh { get; set; }
    }
}
