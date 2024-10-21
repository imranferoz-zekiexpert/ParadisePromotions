using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Core.Interfaces.IServices.IReportsServices
{
    public interface IBuyingHistoryService
    {
        Task<bool> CreateBuyingHistory(BuyingHistory buyingHistory);
        Task<IEnumerable<BuyingHistory>> GetAllBuyingHistory();
        Task<BuyingHistory> GetBuyingHistoryById(int id);
        Task<bool> UpdateBuyingHistory(BuyingHistory buyingHistory);
        Task<bool> DeleteBuyingHistory(int id);
    }
}
