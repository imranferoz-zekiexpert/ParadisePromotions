using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface ITouchLogService
    {
        Task<bool> CreateTouchLog(TouchLog touchLog);
        Task<IEnumerable<TouchLog>> GetAllTouchLog();
        Task<TouchLog> GetTouchLogById(int id);
        Task<bool> UpdateTouchLog(TouchLog touchLog);
        Task<bool> DeleteTouchLog(int id);
    }
}
