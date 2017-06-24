using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVien
    {
        public static int Insert(DTO.NhanVien nv)
        {
            DAL.ModelTableAdapters.NhanVienTableAdapter adap = new DAL.ModelTableAdapters.NhanVienTableAdapter();
            bool gt = true;
            if (nv.GioiTinh == "0") gt = false;
            DataTable b = new DataTable();
            try
            {
                adap.InsertQuery(nv.MaNV, nv.Ho, nv.Ten, gt, nv.NgaySinh, nv.Diachi, nv.ChucVu, nv.SoDienThoai); return 1;
            }
            catch { return 0; }
        }
        public static int Update(DTO.NhanVien nv)
        {
            DAL.ModelTableAdapters.NhanVienTableAdapter adap = new DAL.ModelTableAdapters.NhanVienTableAdapter();
            bool gt = true;
            if (nv.GioiTinh == "0") gt = false;
            DataTable b = new DataTable();
            try
            {
                adap.UpdateQuery(nv.MaNV, nv.Ho, nv.Ten, gt, nv.NgaySinh, nv.Diachi, nv.ChucVu, nv.SoDienThoai); return 1;
            }
            catch { return 0; }
        }

        public static DAL.Model.ChucvuDataTable SelecAllCV()
        {
            DAL.ModelTableAdapters.ChucvuTableAdapter adap = new DAL.ModelTableAdapters.ChucvuTableAdapter();
            return adap.GetData();
        }
        public static DAL.Model.NhanVienDataTable SelecAllNhanVien()
        {
            DAL.ModelTableAdapters.NhanVienTableAdapter adap = new DAL.ModelTableAdapters.NhanVienTableAdapter();
            return adap.GetData();
        }
        public static int Delete(string mnv)
        {
            DAL.ModelTableAdapters.NhanVienTableAdapter adap = new DAL.ModelTableAdapters.NhanVienTableAdapter();
            try { return adap.DeleteQuery(mnv);  } catch { return 0; }
           
        }

    }
}
