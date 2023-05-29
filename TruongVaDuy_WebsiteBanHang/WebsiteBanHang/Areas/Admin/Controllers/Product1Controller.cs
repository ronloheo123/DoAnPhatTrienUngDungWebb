using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;
using static WebsiteBanHang.Models.Common;

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
            Common objCommon =new Common();
           //lấy dữ liệu danh mục dưới DB
           var lstCat=objWebsiteBanHangEntities.Categories.ToList();
            //Convert sang select list dạng value ,text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");


            //lấy dữ liệu thương hiệu dưới DB
            var lstBrand= objWebsiteBanHangEntities.Brands.ToList();
            DataTable dtBrand= converter.ToDataTable(lstBrand);
            //convert sang  select list  dạng value ,text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            //loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            //convert sang  select list  dạng value ,text
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");

            return View();


        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            if(ModelState .IsValid)
            {
                try
                {
                    if(objProduct.ImageUpload!=null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        //tenhinh
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        //png
                        filename = filename + extension;
                        //tenhinh.png
                        objProduct.Avatar = filename;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), filename));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    objWebsiteBanHangEntities.Products.Add(objProduct);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objProduct);
        }
    }
}