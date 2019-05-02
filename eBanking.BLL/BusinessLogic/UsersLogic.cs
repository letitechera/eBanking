using eBanking.DAL.Repositories;
using eBanking.Model.DBModel;
using System.Collections.Generic;

namespace eBanking.BLL.BusinessLogic
{
    public class UsersLogic: IUsersLogic
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<Account> _accountsRepository;

        public UsersLogic(IRepository<User> usersRepository, IRepository<Account> accountsRepository)
        {
            _usersRepository = usersRepository;
            _accountsRepository = accountsRepository;
        }

        public IEnumerable<Account> GetAccountsByUser(int userId)
        {
            return _accountsRepository.List(a => a.UserId == userId);
        }
    }
}
