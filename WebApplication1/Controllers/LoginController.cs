using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        private QuanLiEntities _db = new QuanLiEntities();
        // GET: Home

        //GET: Register

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //POST: Register
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(USER_LOGIN _user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var check = _db.USER_LOGIN.FirstOrDefault(s => s.Email == _user.Email);
        //        if (check == null)
        //        {
        //            _user.Password = GetMD5(_user.Password);
        //            _db.Configuration.ValidateOnSaveEnabled = false;
        //            _db.Users.Add(_user);
        //            _db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Email already exists";
        //            return View();
        //        }


        //    }
        //    return View();


        //}

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoginUser(string LoginName, string password)
        {
            if (LoginName != null && password != null)
            {


                var f_password = GetMD5(password);
                var data = _db.USER_LOGIN.Where(s => s.LOGIN_NAME == LoginName && s.PASSWORD == f_password).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["idUser"] = data.FirstOrDefault().ID;
                    Session["FullName"] = data.FirstOrDefault().FULL_NAME;
                    //return RedirectToAction("Index", "Home");
                    HomeController home = new HomeController { ControllerContext = ControllerContext };
                    return home.Index();
                }
                else
                {
                    ViewBag.error = "Đăng Nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
    
