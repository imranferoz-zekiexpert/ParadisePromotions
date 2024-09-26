using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class QryBlankSalePrintGreenSheetMainRepository :GenericRepository<QryBlankSalePrintGreenSheetMain>, IQryBlankSalePrintGreenSheetMainRepository
    {
        public QryBlankSalePrintGreenSheetMainRepository(DBContextClass dbContext):base(dbContext) { }
    }
}