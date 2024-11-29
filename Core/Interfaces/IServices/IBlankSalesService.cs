using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IBlankSalesService
    {
        Task<bool> CreateBlankSale(BlankSale blankSale);
        Task<IEnumerable<BlankSale>> GetAllBlankSales();
        Task<BlankSale> GetBlankSaleById(int id);
        Task<bool> UpdateBlankSale(BlankSale blankSale);
        Task<bool> DeleteBlankSale(int id);
        Task<IEnumerable<BlankSale>> GetSalesCount(SalesFilter filter);
    }
}
