using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class TimeZonesRepository :GenericRepository<TimeZones>, ITimeZonesRepository
    {
        public TimeZonesRepository(DBContextClass dbContext):base(dbContext) { }
    }
}