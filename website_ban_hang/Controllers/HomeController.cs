using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using website_ban_hang.Context;
using website_ban_hang.Models;

namespace website_ban_hang.Controllers
{
    public class HomeController : Controller
    {
        WebsiteBanHangEntities2 objWebsiteBanHangEntities = new WebsiteBanHangEntities2();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListCategory = objWebsiteBanHangEntities.Categories.ToList();

            objHomeModel.ListProduct = objWebsiteBanHangEntities.Products.ToList();
            return View(objHomeModel);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _users)
        {
            if (ModelState.IsValid)
            {
                var check = objWebsiteBanHangEntities.Users.FirstOrDefault(s => s.Email == _users.Email);
                if (check == null)
                {
                    _users.Password = GetMD5(_users.Password);
                    objWebsiteBanHangEntities.Configuration.ValidateOnSaveEnabled = false;
                    objWebsiteBanHangEntities.Users.Add(_users);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Emailalready exists";
                }
            }
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = objWebsiteBanHangEntities.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for(int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}