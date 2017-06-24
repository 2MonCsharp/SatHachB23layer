using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Thi
    {

        public static DAL.Model.DotThiDataTable DsDotthi()
        {
            DAL.ModelTableAdapters.DotThiTableAdapter adap = new DAL.ModelTableAdapters.DotThiTableAdapter();
            return adap.GetData();
        }
    }
}
