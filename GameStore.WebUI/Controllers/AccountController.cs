using System.Web.Mvc;
using GameStore.WebUI.Infrastructure.Abstract;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    //контроллер для входа в систему
    public class AccountController : Controller
    {
        readonly IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login()
        {
            return View();
        }

        //здесь сама авторизация
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                //при удачной авторизации
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
	}
}