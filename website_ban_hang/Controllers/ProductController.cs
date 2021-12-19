using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_ban_hang.Context;

namespace website_ban_hang.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities2 objWebsiteBanHangEntities = new WebsiteBanHangEntities2();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}