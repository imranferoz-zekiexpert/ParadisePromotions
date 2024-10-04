using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.Codes
{
    public class PrintLocationRepository : GenericRepository<PrintLocation>, IPrintLocationRepository
    {
        public PrintLocationRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}