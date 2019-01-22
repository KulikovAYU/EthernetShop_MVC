using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameStore.Domain.EMDB.Repositories.Interfaces;
using GameStore.Domain.EMDButils;
using GameStore.Domain.Entities;

namespace GameStore.Domain.EMDB.Repositories.Classes
{
    public class GameRepo : RepositoryBase<Game>, IGameRepo
    {
        public GameRepo(DbContext context) : base(context)
        {

        }

        //TODO: добавить сюда методы для работы с играми
        public IEnumerable<string> AllCatergories => GetAll().Select(game => game.Genre).Distinct().OrderBy(x => x);

        //Сохранить игру
        public int SaveGame(Game game)
        {
            Add(game);
            return SaveChanges();
        }
   
        //удалить иггру
        public int RemoveGame(Game game)
        {
            Remove(game);
            return SaveChanges();
        }

        /// <summary>
        /// удалить игру из БД по ID (с сохранением изменений)
        /// </summary>
        /// <param name="gameId">Id игры</param>
        /// <param name="outGame">Игра, которая была удалена</param>
        /// <returns>результат сохранения в БД</returns>
        public int RemoveGame(int gameId, ref Game outGame)
        {
           Game gameToDelete = Get(gameId);
            //создадим копию
           outGame = gameToDelete.CloneGame();
           return RemoveGame(gameToDelete);
        }

        /// <summary>
        /// Вернуть игры на странице
        /// </summary>
        /// <param name="category">название категории игры</param>
        /// <param name="page">страница</param>
        /// <returns>результат сохранения в БД</returns> 
        public IEnumerable<Game> GetGamesOnPage(string category, int page ,int pageSize)
        {
           return Find(game => category == null || game.Genre == category).OrderBy(game => game.GameId).Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
