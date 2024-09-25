using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IInvoicesService
    {
        Task<bool> CreateInvoice(Invoice invoice);
        Task<IEnumerable<Invoice>> GetAllInvoices();
        Task<Invoice> GetInvoiceById(int id);
        Task<bool> UpdateInvoice(Invoice invoice);
        Task<bool> DeleteInvoice(int id);
    }
}
