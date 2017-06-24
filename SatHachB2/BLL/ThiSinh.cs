using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThiSinh
    {
        public static DTO.ThiSinh ThongTinThiSinh(string  MsThiSinh)
        {
            DTO.ThiSinh ts = new DTO.ThiSinh();
            DataTable data = new DataTable();
            data=DAL.ThiSinh.ThongTinThiSinh(MsThiSinh);
            DataRow row = data.Rows[0];
            ts.Ho = row["Ho"].ToString();
            ts.Ten = row["Ten"].ToString();
            ts.NgaySinh = row["NgaySinh"].ToString();
            ts.GioiTinh = row["GioiTinh"].ToString();
            ts.DiaChi = row["DiaChi"].ToString();
            ts.QuocTich = row["QuocTich"].ToString();
            ts.CMND = row["CMND"].ToString();
            if (row["HinhAnh"].ToString() != "")
                ts.HinhAnh = row["HinhAnh"].ToString();
            else
               ts.HinhAnh = "avatar.png";
            return ts;
        }
        public static int Add(DTO.ThiSinh ts)
        {
          return  DAL.ThiSinh.Add(ts);
           
        }
        public static int UpdateXN(String str,String SBD)
        {
            return DAL.ThiSinh.UpdateXacNhan(str, SBD);
        }
        public static int Suathisinh(DTO.ThiSinh ts,string msts)
        {

            return DAL.ThiSinh.SuaThiSinh(ts, msts);

        }
        public static DataTable Find(String cmd,bool issbd)
        {
            return DAL.ThiSinh.Find(cmd,issbd);
        }
    }
}
