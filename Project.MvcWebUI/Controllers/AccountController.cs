using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.MvcWebUI.Identity;
using Project.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Project.MvcWebUI.Entity;

namespace Project.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManageer;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManageer = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index() 
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i=>i.Username==username).Select(i=> new UserOrderModel() 
            {
                Id=i.Id,
                OrderNumber=i.OrderNumber,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total
            }).OrderByDescending(i=> i.OrderDate).ToList();


            return View(orders);
        }

        [Authorize]
        public ActionResult Details(int id) 
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel() 
            {
                OrderId=i.Id,
                OrderNumber=i.OrderNumber,
                Total=i.Total,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                AdresBasligi=i.AdresBasligi,
                Adres=i.Adres,
                Sehir=i.Sehir,
                Semt=i.Semt,
                Mahelle=i.Mahelle,
                PostaKodu=i.PostaKodu,
                OrderLines=i.OrderLines.Select(a=>new OrderLineModel() 
                {
                    ProductId=a.ProductId,
                    ProductName=a.Product.Name.Length>50?a.Product.Name.Substring(0,47)+"...":a.Product.Name,
                    Image=a.Product.Image,
                    Quantity=a.Quantity,
                    Price=a.Price
                }).ToList()
            }).FirstOrDefault();
                

            return View(entity);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        // Post: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Valid ise kayıt işlemleri
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result =  UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kayıt gerçeklesti ve rol atanabilir
                    if (RoleManageer.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    //false döndü
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı  oluşturma hatası.");
                }

            }
            return View(model);
        }


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // Post: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Valid ise login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    //kullanıcı var ise sisteme ekle
                    //ApplicationCookie oluştur sisteme bırak

                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProperties, identityclaims);

                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //kullanıcı yok ise
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }

    }

}