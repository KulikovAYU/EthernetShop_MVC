using System;
using GameStore.Domain.EMDB.Repositories.Interfaces;

namespace GameStore.Domain.EMDB
{
    /// <summary>
    /// Репозиторий сущностей для БД
    /// </summary>
   public interface IUnitOfWork : IDisposable
    {
        //Репозиторий игр
        IGameRepo Games { get; }

        //TODO: разместите здесь интерфейсы для репозиториев


        //Завершает работу с репозиторием, сохраняя сущности в БД
        int Complete();
    }
}
