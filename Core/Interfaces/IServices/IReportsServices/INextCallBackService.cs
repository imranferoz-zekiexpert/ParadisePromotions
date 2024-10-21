using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Core.Interfaces.IServices.IReportsServices
{
    public interface INextCallBackService
    {
        Task<bool> CreateNextCallBack(NextCallBack nextCallBack);
        Task<IEnumerable<NextCallBack>> GetAllNextCallBack();
        Task<NextCallBack> GetNextCallBackById(int id);
        Task<bool> UpdateNextCallBack(NextCallBack nextCallBack);
        Task<bool> DeleteNextCallBack(int id);
    }
}
