using System.Data.Entity;
using GameStore.Domain.EMDB.Repositories.Interfaces;
using GameStore.Domain.Entities;

namespace GameStore.Domain.EMDB.Repositories.Classes
{
    public class AccountRepo : RepositoryBase<AccountAdm>, IAccountRepo
    {
        public AccountRepo(DbContext context) : base(context)
        {
        }

        public AccountAdm GetAccount(string userName, string userPass)
        {
            return SingleOrDefault(account => account.Password == userPass && account.UserName == userName);
        }
    
    }
}
