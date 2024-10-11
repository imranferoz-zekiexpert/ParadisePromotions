using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IBonusService
    {
        Task<bool> CreateBonus(Bonus bonus);
        Task<IEnumerable<Bonus>> GetAllBonus();
        Task<Bonus> GetBonusById(int id);
        Task<bool> UpdateBonus(Bonus bonus);
        Task<bool> DeleteBonus(int id);
    }
}
