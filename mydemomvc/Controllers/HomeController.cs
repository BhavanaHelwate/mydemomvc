using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mydemomvc.Models;



namespace mydemomvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetailsIndex(int ID)
        {
            ViewBag.ID = ID;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult registration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Savereg(registrationModel model)
        {
            try
            {
                return Json(new { Message = new registrationModel().Savereg(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetregistrationList()
        {
            try
            {
                return Json(new { model = new registrationModel().GetregistrationList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deleteregistration(int ID)
        {
            try
            {
                return Json(new { model = new registrationModel().deleteregistration(ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getregistrationbyID(int ID)
        {
            try
            {
                return Json(new { model = new registrationModel().getregistrationbyID(ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
     