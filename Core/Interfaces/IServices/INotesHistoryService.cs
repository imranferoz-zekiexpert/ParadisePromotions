using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface INotesHistoryService
    {
        Task<bool> CreateNotesHistory(NotesHistory noteHistory);
        Task<IEnumerable<NotesHistory>> GetAllNotesHistory();
        Task<NotesHistory> GetNotesHistoryById(int id);
        Task<bool> UpdateNotesHistory(NotesHistory noteHistory);
        Task<bool> DeleteNotesHistory(int id);
    }
}
