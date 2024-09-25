using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IInvoiceDetailsService
    {
        Task<bool> CreateInvoiceDetail(InvoiceDetail invoiceDetail);
        Task<IEnumerable<InvoiceDetail>> GetAllInvoiceDetails();
        Task<InvoiceDetail> GetInvoiceDetailById(int id);
        Task<bool> UpdateInvoiceDetail(InvoiceDetail invoiceDetail);
        Task<bool> DeleteInvoiceDetail(int id);
    }
}
