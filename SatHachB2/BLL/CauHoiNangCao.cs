using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CauHoiNangCao
    {
        public static DataTable SelectAll()
        {
            return DAL.CauHoiNangCao.DanhSachCauHoi();
        }
        public static DataTable DanhSachCauHoiByChuDe(string key)
        {
            return DAL.CauHoiNangCao.DanhSachCauHoiByChuDe(key);
        }
        public static DataTable DanhSachChuDe()
        {
            return DAL.CauHoiNangCao.DanhSachChuDe();
        }
        public static int AddQuestion2DA(DTO.CauHoi2DA ch)
        {
            return DAL.CauHoiNangCao.AddQuestion2DA(ch);
        }
        public static int AddQuestion3DA(DTO.CauHoi3DA ch)
        {
            return DAL.CauHoiNangCao.AddQuestion3DA(ch);
        }
        public static int AddQuestion4DA(DTO.CauHoi4DA ch)
        {
            return DAL.CauHoiNangCao.AddQuestion4DA(ch);
        }
    }
}
