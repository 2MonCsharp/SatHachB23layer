using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class ThiSinh
    {
        public static DataTable ThongTinThiSinh(String sbd) { 
        string cmd = "select Ho,Ten,NgaySinh,Case (GioiTinh) When 1 then 'Nam' When 0 then 'Nữ' end as GioiTinh,DiaChi,QuocTich,CMND,HinhAnh from ThiSinh where MsThiSinh='" + sbd + "'";
          return  ConnectDB.execAdapter(cmd);
        }
        
        public static int Add(DTO.ThiSinh ts)
        {

          string cmd = "EXEC NhapThiSinh '" + ts.MsThiSinh + "',N'" + ts.Ho + "',N'" + ts.Ten + "','" + ts.NgaySinh + "'," + ts.GioiTinh + ",N'" + ts.QuocTich + "',N'" + ts.DiaChi + "','" + ts.HinhAnh + "','" + ts.CMND + "'";
          return ConnectDB.ExecuteNonQuery(cmd);
        }
        public static int UpdateXacNhan(String str,String SBD)
        {
           
            string cmd = "UPDATE ThiSinh SET PhanHoi='" + str + "' WHERE MsThiSinh='" + SBD + "'";
            return ConnectDB.ExecuteNonQuery(cmd);
        }
        public static int SuaThiSinh(DTO.ThiSinh ts,string msts)
        {
            string cmd = "EXEC SuaThiSinh '" +msts+"','"+ ts.MsThiSinh + "',N'" + ts.Ho + "',N'" + ts.Ten + "','" + ts.NgaySinh + "'," + ts.GioiTinh + ",N'" + ts.QuocTich + "',N'" + ts.DiaChi + "','" + ts.HinhAnh + "','" + ts.CMND + "'";
            return ConnectDB.ExecuteNonQuery(cmd);
        }
        public static DataTable Find(String key,bool bysbd)
        {
            string cmd = "";
            if (!key.Equals("")) { 
            if (bysbd)
            {
                
                cmd = "Select * from ThiSinh where MsThiSinh='" + key + "'";
            }
            else { cmd = "Select* from ThiSinh where Upper(Ho) LIKE Upper('%" + key + "%') OR(Upper(Ten) LIKE Upper('%" + key + "%'))ORDER BY Ten"; }
            }
            else { cmd = "Select * from ThiSinh"; }
            return ConnectDB.execAdapter(cmd);
        }
    }
}
