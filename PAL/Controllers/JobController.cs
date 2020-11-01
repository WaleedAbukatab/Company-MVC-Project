using BAL;
using Entities.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PAL.Controllers
{
    public class JobController : Controller
    {
        Job job = new Job();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            DataTable dt = GetJobs();
            List<Job> jobsList = new List<Job>();
            jobsList = (from DataRow dr in dt.Rows
                           select new Job()
                           {
                               id = Convert.ToInt32(dr["id"]),
                               jobid = Convert.ToInt32(dr["jobid"]),
                               jobdesc = dr["jobdesc"].ToString(),
                               jobtitle = dr["jobtitle"].ToString(),
                               firstname = dr["firstname"].ToString()
                           }).ToList();

            return Json(new { data = jobsList }, JsonRequestBehavior.AllowGet);

        }

        // GET: Job
        private DataTable GetJobs(string jobname = null)
        {
            try

            {
                DataTable jobs = JobsBAL.GetAllJobs(jobname);
                return jobs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}