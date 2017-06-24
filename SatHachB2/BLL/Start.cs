using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Start
    {
        public static bool isSBDtrue(String ts, String bt)
        {
            DataTable temp= new DataTable();
            temp = DAL.Start.table_ThiSinh(ts);
            
            if (temp.Rows.Count == 1)
            {
                temp = DAL.Start.table_DotThi(bt);
                if (temp.Rows.Count == 1)
                {
                    temp = DAL.Start.table_BaiThi(ts, bt);

                    return (bool)temp.Rows[0]["IsChuaLam"];

                }
            }
            return false;
        }
    }
}
