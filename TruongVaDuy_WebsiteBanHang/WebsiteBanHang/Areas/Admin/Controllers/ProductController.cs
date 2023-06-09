using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using static WebsiteBanHang.Models.Common;
using WebsiteBanHang.Models;
using PagedList;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            var lstProduct = new List<Product>();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                //lấy ds sản phẩm theo từ khóa tìm kiếm
                lstProduct = objWebsiteBanHangEntities.Products.Where(n => n.Name.Contains(searchString)).ToList();
            }
            else
            {
                //lấy all sản phẩm  trong bản Product
                lstProduct = objWebsiteBanHangEntities.Products.ToList();
            }
            ViewBag.CurrentFilter = searchString;
            //số lượng item của  1 trang =4;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            Common objCommon = new Common();
            //lấy dữ liệu danh mục dưới DB
            var lstCat = objWebsiteBanHangEntities.Categories.ToList();
            //Convert sang select list dạng value ,text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");


            //lấy dữ liệu thương hiệu dưới DB
            var lstBrand = objWebsiteBanHangEntities.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
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
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
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

