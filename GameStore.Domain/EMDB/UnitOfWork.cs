using GameStore.Domain.EMDB.Repositories.Classes;
using GameStore.Domain.EMDB.Repositories.DBContext;
using GameStore.Domain.EMDB.Repositories.Interfaces;

namespace GameStore.Domain.EMDB
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext m_context;

        public UnitOfWork(EFDbContext context)
        {
            m_context = context;
            IntitializeRepo();
        }

        public void Dispose()
        {
            m_context.SaveChanges();
        }

        public int Complete()
        {
            return m_context.SaveChanges();
        }

        /// <summary>
        /// Инициализация всех репозиториев
        /// </summary>
        private void IntitializeRepo()
        {
            Games = new GameRepo(m_context);

            //TODO: инстанцируйте новые репозитории
        }

        //Interfaces
        public IGameRepo Games { get; private set; }
    }
}
