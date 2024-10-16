using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IChargeBackService
    {
        Task<bool> CreateChargeBack(ChargeBack chargeBack);
        Task<IEnumerable<ChargeBack>> GetAllChargeBack();
        Task<ChargeBack> GetChargeBackById(int id);
        Task<bool> UpdateChargeBack(ChargeBack chargeBack);
        Task<bool> DeleteChargeBack(int id);
    }
}
