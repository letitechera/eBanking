using eBanking.Model.ApiModels;
using eBanking.Model.DBModel;

namespace eBanking.BLL.BusinessLogic
{
    public interface ITransferencesLogic
    {
        ApiResult CompleteTransference(Transference tr);
    }
}
