using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Core.Interfaces.IServices.IReportsServices
{
    public interface ILastDispositionService
    {
        Task<bool> CreateLastDisposition(LastDisposition lastDisposition);
        Task<IEnumerable<LastDisposition>> GetAllLastDisposition();
        Task<LastDisposition> GetLastDispositionById(int id);
        Task<bool> UpdateLastDisposition(LastDisposition lastDisposition);
        Task<bool> DeleteLastDisposition(int id);
    }
}
