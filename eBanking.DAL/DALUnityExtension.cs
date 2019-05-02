using eBanking.DAL.Repositories;
using eBanking.Model.DBModel;
using Microsoft.Practices.Unity;

namespace eBanking.DAL
{
    public class DALUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterInstance(new eBankingContext(), new PerResolveLifetimeManager());

            Container.RegisterType<IRepository<User>, Repository<User>>();
            Container.RegisterType<IRepository<Account>, Repository<Account>>();
            Container.RegisterType<IRepository<AccountType>, Repository<AccountType>>();
            Container.RegisterType<IRepository<Transference>, Repository<Transference>>();
        }
    }
}
