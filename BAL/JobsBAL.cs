using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class JobsBAL
    {
        public static DataTable GetAllJobs(string name = null)
        {
            try
            {
                return JobsDAL.GetAllJobs(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
