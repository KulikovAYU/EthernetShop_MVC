using System.Web.Security;
using GameStore.WebUI.Infrastructure.Abstract;

namespace GameStore.WebUI.Infrastructure.Concrete
{
    public class FormAuthProvider : IAuthProvider
    {
        /// <summary>
        /// позволяет проверить учетные данные, предоставленные пользователем
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            //добавляет cookie к ответу, предназначенному для браузера, чтобы пользователям не
            //пришлось проходить аутентификацию каждый раз, когда они делают запрос.
            if (result)
                FormsAuthentication.SetAuthCookie(username, false);
            return result;
        }
    }
}