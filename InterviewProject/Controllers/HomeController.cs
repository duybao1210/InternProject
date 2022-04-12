using InterviewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewProject.Controllers
{
    public class HomeController : Controller
    {

        private VNR_InternShipEntities db = new VNR_InternShipEntities();
        public ActionResult Index()
        {          
            return View();
        }
        public ActionResult ListCourse()
        {
            List<KhoaHoc> lstCourse = db.KhoaHocs.ToList();
            return View(lstCourse);
        }

        public ActionResult DetailCourse(int? id)
        {
            Session["nameCourse"] = null;
            if (id != null)
            {
                var Course = db.KhoaHocs.Find(id);
                Session["nameCourse"] = Course.TenKhoaHoc;
            }
            List<MonHoc> lstSubject = db.MonHocs.Where(p => p.KhoaHocID == id).ToList();
            Session["idCourse"] = null;          
            return PartialView("DetailCourse",lstSubject);
        }
    }
}