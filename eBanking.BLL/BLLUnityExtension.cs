using eBanking.BLL.BusinessLogic;
using eBanking.DAL;
using Microsoft.Practices.Unity;


namespace eBanking.BLL
{
    public class BLLUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<DALUnityExtension>();
            Container.RegisterType<ITransferencesLogic, TransferencesLogic>();
            Container.RegisterType<IUsersLogic, UsersLogic>();
        }
    }
}
