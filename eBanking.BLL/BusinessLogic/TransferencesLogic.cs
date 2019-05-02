using eBanking.DAL;
using eBanking.DAL.Repositories;
using eBanking.Model.ApiModels;
using eBanking.Model.DBModel;
using System.Linq;

namespace eBanking.BLL.BusinessLogic
{
    public class TransferencesLogic : ITransferencesLogic
    {
        private readonly IRepository<Account> _accountsRepository;
        private readonly IRepository<Transference> _transferencesRepository;

        public TransferencesLogic(
            IRepository<Account> accountsRepository,
            IRepository<Transference> transferencesRepository)
        {
            _accountsRepository = accountsRepository;
            _transferencesRepository = transferencesRepository;
        }

        public ApiResult CompleteTransference(Transference tr)
        {
            var origin = _accountsRepository.FindById(tr.OriginAccountId);

            if (tr.Amount > origin.Balance)
            {
                return new ApiResult { Success = false, ErrorMessage = "La cuenta no tiene saldo suficiente" };
            }

            var destination = _accountsRepository.FindById(tr.DestinationAccountId);

            try
            {
                origin.Balance = origin.Balance - tr.Amount;
                destination.Balance = destination.Balance + tr.Amount;

                _accountsRepository.Update(origin, false);
                _accountsRepository.Update(destination, false);
                _transferencesRepository.Add(tr, false);

                _accountsRepository.SaveChanges();
                _transferencesRepository.SaveChanges();

                return new ApiResult { Success = true };
            }
            catch
            {
                return new ApiResult { Success = false, ErrorMessage = "La transacción no se pudo realizar." };
            }
        }
    }
}
