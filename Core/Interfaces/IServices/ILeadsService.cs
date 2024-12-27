using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface ILeadsService
    {
        Task<bool> CreateLeads(Lead lead);
        Task<IEnumerable<Lead>> GetAllLeads();
        Task<Lead> GetLeadsById(int id);
        Task<bool> UpdateLeads(IEnumerable<Lead> lead);
        Task<bool> DeleteLeads(int id);
        Task<IEnumerable<Lead>> GetLeadsCount(LeadsFilter filter);
    }
}
