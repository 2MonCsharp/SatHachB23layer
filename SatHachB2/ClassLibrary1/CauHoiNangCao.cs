using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CauHoiNangCao
    {
        public static DataTable DanhSachCauHoi()
        {
            String cmd = " SELECT *  FROM[ThiB2].[dbo].[View_DanhSachCauHoi]";
            return ConnectDB.execAdapter(cmd);
        }
        public static DataTable DanhSachCauHoiByChuDe(String key)
        {
            string cmd = "SELECT *  FROM[ThiB2].[dbo].[View_DanhSachCauHoi] Where [MsChuDe]='" + key + "' ";
          
            return ConnectDB.execAdapter(cmd);
        }
        public static DataTable DanhSachChuDe()
        {
            String cmd = "SELECT * FROM[ThiB2].[dbo].[ChuDeCauHoi]";
            return ConnectDB.execAdapter(cmd);
        }
        public static int AddQuestion2DA(DTO.CauHoi2DA ch)
        {
            string cmd = "EXEC Nhapcauuhoi2dapan '"+ch.Cauhoi+"','"+ch.MsChuDe+"',N'"+ ch.DapAn1+"',N'"+ch.DapAn2  +"','"+ch.DA1right +"','"+ ch.DA2right +"'";
            return ConnectDB.ExecuteNonQuery(cmd);
        }
        public static int AddQuestion3DA(DTO.CauHoi3DA ch)
        {
            string cmd = "EXEC Nhapcauuhoi3dapan '" + ch.Cauhoi + "','" + ch.MsChuDe + "',N'" + ch.DapAn1 + "',N'" + ch.DapAn2 + "',N'"+ch.DapAn3+"','" + ch.DA1right + "','" + ch.DA2right + "','"+ch.DA3right+"'";
            return ConnectDB.ExecuteNonQuery(cmd);
        }
        public static int AddQuestion4DA(DTO.CauHoi4DA ch)
        {
            string cmd = "EXEC Nhapcauuhoi4dapan '" + ch.Cauhoi + "','" + ch.MsChuDe + "',N'" + ch.DapAn1 + "',N'" + ch.DapAn2 + "',N'" + ch.DapAn3 + "',N'"+ch.DapAn4+"','" + ch.DA1right + "','" + ch.DA2right + "','" + ch.DA3right + "','"+ch.DA4right+"'";
            return ConnectDB.ExecuteNonQuery(cmd);
        }
    }
}
