
using GameStore.Domain.Entities;

namespace GameStore.Domain.EMDB.Repositories.Interfaces
{
    public interface IAccountRepo : IReporitoryBase<AccountAdm>
    {
        //вернуть аккаунт
        AccountAdm GetAccount(string userName, string userPass);
    }
}
