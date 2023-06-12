using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class OdersController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities =new WebsiteBanHangEntities();
        // GET: Admin/Oders
        public ActionResult Index()
        {
            var lstOders = objWebsiteBanHangEntities.Orders.ToList();
            return View(lstOders);
        }
        public ActionResult Details(int id) 
        {
            var objOders = objWebsiteBanHangEntities.Orders.Where(n => n.Id == id).FirstOrDefault();
            
            return View(objOders);
        }
        public ActionResult Edit(int id)
        {
            var objOders = objWebsiteBanHangEntities.Orders.Where(n => n.Id == id).FirstOrDefault();

            return View(objOders);
        }
        public ActionResult Delete(Order od) 
        {
            var objOders = objWebsiteBanHangEntities.Orders.Where(n => n.Id ==od.Id).FirstOrDefault();
            objWebsiteBanHangEntities.Orders.Remove(objOders);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}