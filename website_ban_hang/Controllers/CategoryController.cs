using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_ban_hang.Context;

namespace website_ban_hang.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        WebsiteBanHangEntities2 objWebsiteBanHangEntities = new WebsiteBanHangEntities2();
        public ActionResult Index()
        {
            var listCategory = objWebsiteBanHangEntities.Categories.ToList();
            return View(listCategory);
        }

        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objWebsiteBanHangEntities.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
    }
}