using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.Domain.EMDB.Repositories.Interfaces
{
    public interface IGameRepo : IReporitoryBase<Game>
    {
        //получить все категории игр
        IEnumerable<string> AllCatergories { get; }
        //сохранить игру в БД (с сохранением изменений)
        int SaveGame(Game game);

        /// <summary>
        /// удалить игру из БД по ID (с сохранением изменений)
        /// </summary>
        /// <param name="gameId">Id игры</param>
        /// <param name="outGame">Игра, которая была удалена</param>
        /// <returns>результат сохранения в БД</returns>
        int RemoveGame(int gameId, ref Game outGame);

        /// <summary>
        /// Вернуть игры на странице
        /// </summary>
        /// <param name="category">название категории игры</param>
        /// <param name="page">страница</param>
        /// <returns>результат сохранения в БД</returns>
        IEnumerable<Game> GetGamesOnPage(string category, int page, int pageSize);
       
    }
}