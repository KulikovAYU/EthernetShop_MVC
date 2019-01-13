using System.Linq;
using System.Web.Mvc;
using GameStore.Domain.EMDB;
using GameStore.Domain.EMDB.Repositories.Interfaces;
using GameStore.Domain.Entities;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepo repository;
        public int pageSize = 4;

        public GameController(IUnitOfWork repo)
        {
            repository = repo.Games;
        }

        public ViewResult List(string category, int page = 1)
        {
            GamesListViewModel model = new GamesListViewModel
            {
                Games = repository.GetGamesOnPage(category, page,pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        repository.GetAll().Count() :
                        repository.Find(game => game.Genre == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int gameId)
        {
            Game game = repository.Get(gameId);
           
            if (game != null)
            {
                return File(game.ImageData, game.ImageMimeType);
            }

            return null;
        }
	}
}