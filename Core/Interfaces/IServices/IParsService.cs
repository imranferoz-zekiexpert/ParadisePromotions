using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IParsService
    {
        Task<bool> CreatePars(Pars pars);
        Task<IEnumerable<Pars>> GetAllPars();
        Task<Pars> GetParsById(int id);
        Task<bool> UpdatePars(Pars pars);
        Task<bool> DeletePars(int id);
    }
}
