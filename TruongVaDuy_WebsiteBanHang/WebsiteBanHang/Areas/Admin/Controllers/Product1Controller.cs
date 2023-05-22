using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class Product1Controller : Controller
    {
        // GET: Admin/Product1
        WebsiteBanHangEntities objWebsiteBanHangEntities= new WebsiteBanHangEntities();
        public ActionResult Index()
        {
            var lstProduct = objWebsiteBanHangEntities.Products.ToList();
            return View(lstProduct);
        }
        public ActionResult Details(int Id)
        {
            var objProduct= objWebsiteBanHangEntities.Products.Where(n=>n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public  ActionResult Create()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            return View();
        }
    }
}