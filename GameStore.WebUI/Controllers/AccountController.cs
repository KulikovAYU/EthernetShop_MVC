using System.Web.Mvc;
using GameStore.Domain.EMDB;
using GameStore.Domain.Entities;
using GameStore.WebUI.Models;
using MvcInternetApplication.Filters;
using WebMatrix.WebData;

namespace GameStore.WebUI.Controllers
{
    [InitializeSimpleMembership]
    //контроллер для входа в систему
    public class AccountController : Controller
    {
        readonly IUnitOfWork m_repo;
        public AccountController(IUnitOfWork repo)
        {
            m_repo = repo;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        ////здесь сама авторизация
        //[HttpPost]
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        IAuthProvider authProvider = new FormAuthProvider();
        //        //при удачной авторизации
        //        if (authProvider.Authenticate(model.UserName, model.Password))
        //        {
        //            return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Неправильный логин или пароль");
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}


        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel adm, string returnUrl)
        {

           // WebSecurity.CreateUserAndAccount(adm.UserName, adm.Password); //чтобы лишний раз не создавать аккаунт (т.к. формируется хэш)

         
            // WebSecurity.Login - аутентифицирует пользователя.
            // Если логин и пароль введены правильно - метод возвращает значение true после чего выполняет добавление специальных значений в cookies.
            
            if (ModelState.IsValid && WebSecurity.Login(adm.UserName, adm.Password))
            {
                return RedirectToLocal(returnUrl); //Admin
            }

            // Был введен не правильный логин или пароль
            ModelState.AddModelError("", "Был введен не правильный логин или пароль.");
            return View(adm);
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Admin"); 
            }
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            // Удаление специальных аутентификационных cookie значений
            WebSecurity.Logout();

            return RedirectToAction("List", "Game");
        }
    }
}