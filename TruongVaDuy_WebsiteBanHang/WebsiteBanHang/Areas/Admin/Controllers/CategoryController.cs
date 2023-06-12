using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var lstCategory = objWebsiteBanHangEntities.Categories.ToList();
            return View(lstCategory);
        }
    }
}