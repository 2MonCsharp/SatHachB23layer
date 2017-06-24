using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Start
    {
      
       public static DataTable table_ThiSinh( String thisinh)
        {
            string cmd = "select * from ThiSinh where MsThiSinh='" + thisinh + "'";
            return ConnectDB.execAdapter(cmd);


        }
        public static DataTable table_DotThi(String dotThi)
        {
           string  cmd = "select * from DotThi where MaBT='" + dotThi+ "'";
           return ConnectDB.execAdapter(cmd);
        }
        public static DataTable table_BaiThi(String MsThiSinh, String MsBaiThi)
        {
            string cmd = "select * from KiemtraMBT('" + MsThiSinh+ "','" +MsBaiThi + "') ";
            return ConnectDB.execAdapter(cmd);
        }
    }
}
