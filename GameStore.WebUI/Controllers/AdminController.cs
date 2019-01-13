using System.Web.Mvc;
using GameStore.Domain.Entities;
using System.Web;
using GameStore.Domain.EMDB;
using GameStore.Domain.EMDB.Repositories.Interfaces;

namespace GameStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        readonly IGameRepo repository;

        public AdminController (IUnitOfWork repo)
        {
            repository = repo.Games;
        }

        public ViewResult Index()
        {
            return View(repository.GetAll());
        }

        public ViewResult Edit(int gameId)
        {
            return View(repository.Get(gameId));
        }

        [HttpPost]
        public ActionResult Edit(Game game, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    game.ImageMimeType = image.ContentType;
                    game.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(game.ImageData, 0, image.ContentLength);
                }
                repository.SaveGame(game);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", game.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(game);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Game());
        }

        [HttpPost]
        public ActionResult Delete(int gameId)
        {
            Game deletedGame = null;
            repository.RemoveGame(gameId,ref deletedGame);
            if (deletedGame != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    deletedGame.Name);
            }
            return RedirectToAction("Index");
        }
	}
}