using GameStore.Domain.Entities;

//Тут размещаются утилиты для работы с классами
namespace GameStore.Domain.EMDButils
{
    public static class StaticHelper
    {
        //Копируем игру
        public static Game CloneGame(this Game game)
        {
            return new Game()
            {
                GameId = game.GameId,
                Name = game.Name,
                Author = game.Author,
                Description = game.Author,
                Genre = game.Genre,
                ImageData = game.ImageData,
                ImageMimeType = game.ImageMimeType,
                Price = game.Price
            };
        }
    }
}
