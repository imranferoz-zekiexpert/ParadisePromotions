using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface ILeadsService
    {
        Task<bool> CreateLeads(Lead pars);
        Task<IEnumerable<Lead>> GetAllLeads();
        Task<Lead> GetLeadsById(int id);
        Task<bool> UpdateLeads(Lead pars);
        Task<bool> DeleteLeads(int id);
    }
}
