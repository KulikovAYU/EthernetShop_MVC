using System.Collections.Generic;
using System.Web.Mvc;
using GameStore.Domain.EMDB;
using GameStore.Domain.EMDB.Repositories;
using GameStore.Domain.EMDB.Repositories.Interfaces;

namespace GameStore.WebUI.Controllers
{
    /// <summary>
    /// Контроллер навигатора категорий
    /// </summary>
    public class NavController : Controller
    {
        private readonly IGameRepo repository;

        public NavController(IUnitOfWork repo)
        {
            repository = repo.Games;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.AllCatergories;

            return PartialView("FlexMenu", categories);
        }
	}
}