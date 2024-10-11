using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class NotesHistoryRepository :GenericRepository<NotesHistory>, INotesHistoryRepository
    {
        public NotesHistoryRepository(DBContextClass dbContext):base(dbContext) { }
    }
}