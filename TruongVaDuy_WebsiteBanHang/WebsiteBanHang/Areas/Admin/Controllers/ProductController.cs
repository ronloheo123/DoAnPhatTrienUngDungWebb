using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {   
            var lstProduct= objWebsiteBanHangEntities.Products.ToList();
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
                if (objProduct.ImageUpload != null)
                {
                    String fileName= Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    String extension=Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName  +extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                objWebsiteBanHangEntities.Products.Add(objProduct);
                objWebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct= objWebsiteBanHangEntities.Products.Where(n=>n.Id==id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebsiteBanHangEntities.Products.Remove(objProduct);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                String fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                String extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
            }
            objWebsiteBanHangEntities.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}