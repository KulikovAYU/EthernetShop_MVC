using GameStore.Domain.Entities;
using System.Web.Mvc;

namespace GameStore.WebUI.Infrastructure.Binders
{
    /// <summary>
    /// Настройка (см.Global asax):
    /// будет реагировать в том случае, если необходимо инициализировать
    ///  значение параметра типа Cart
    /// </summary>
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerContext">информация о запросе</param>
        /// <param name="bindingContext">информация о привязке</param>
        /// <returns>объект, который будет присвается аргументу метода действия</returns>
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса

            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            // Создать объект Cart если он не обнаружен в сеансе
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            // Возвратить объект Cart
            return cart;
        }
    }
}