using EmpApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;
using Microsoft.Owin.Security;
using System.Web.Security;

namespace EmpApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                using (EmpDBEntities db = new EmpDBEntities())
                {
                    var obj = db.Users.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {

                        //var claims = new List<Claim>();
                        //claims.Add(new Claim(ClaimTypes.Name, obj.Username.ToString()));
                        //var _Role = db.UserRoleMappings.Where(a => a.UserId==obj.Id).FirstOrDefault();
                        //var RoleName = db.Roles.Where(a => a.Id==_Role.RoleId).FirstOrDefault().RoleName;
                        //claims.Add(new Claim(ClaimTypes.Role, RoleName));
                        //var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                     
                        FormsAuthentication.RedirectFromLoginPage(obj.Username.ToString(), true);

                        return RedirectToAction("Index", "Employees");
                    }
                }
            }
            return View(objUser);
        }


    }
}