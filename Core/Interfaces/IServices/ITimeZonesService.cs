using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface ITimeZonesService
    {
        Task<bool> CreateTimeZones(TimeZones timeZone);
        Task<IEnumerable<TimeZones>> GetAllTimeZones();
        Task<TimeZones> GetTimeZonesById(int id);
        Task<bool> UpdateTimeZones(TimeZones timeZone);
        Task<bool> DeleteTimeZones(int id);
    }
}
