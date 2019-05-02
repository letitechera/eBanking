
using eBanking.Model.DBModel;
using System.Collections.Generic;

namespace eBanking.BLL.BusinessLogic
{
    public interface IUsersLogic
    {
        IEnumerable<Account> GetAccountsByUser(int userId);
    }
}
