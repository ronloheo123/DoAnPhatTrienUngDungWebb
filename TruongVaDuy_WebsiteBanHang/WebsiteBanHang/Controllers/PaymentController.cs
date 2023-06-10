using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities= new WebsiteBanHangEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"]==null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //lấy thông tin giỏ hàng từ biến session
                var lstCart = (List<CartModel>)Session["cart"];
                //gán dữ liệu cho oder
                Order objOrder=new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objWebsiteBanHangEntities.Orders.Add(objOrder);
                //lưu thông tin dữ liệu vào bảng oder
                objWebsiteBanHangEntities.SaveChanges();
                //lấy oderid vừa mới tạo để lưu vào bảng oderdetail
                int intOrderId = objOrder.Id;
                List<OderDetail> lstOrderDetail=new List<OderDetail>();
                foreach(var item in lstCart)
                {
                    OderDetail obj= new OderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }    
                objWebsiteBanHangEntities.OderDetails.AddRange(lstOrderDetail);
                objWebsiteBanHangEntities.SaveChanges();

            }
            return View();
        }
    }
}