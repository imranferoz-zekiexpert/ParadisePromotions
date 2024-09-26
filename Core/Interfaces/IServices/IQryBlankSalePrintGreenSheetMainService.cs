using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Interfaces.IServices
{
    public interface IQryBlankSalePrintGreenSheetMainService
    {
        Task<bool> CreateSalePrintGreenSheet(QryBlankSalePrintGreenSheetMain sheet);
        Task<IEnumerable<QryBlankSalePrintGreenSheetMain>> GetAllSalePrintGreenSheet();
        Task<QryBlankSalePrintGreenSheetMain> GetSalePrintGreenSheetById(int id);
        Task<bool> UpdateSalePrintGreenSheet(QryBlankSalePrintGreenSheetMain sheet);
        Task<bool> DeleteSalePrintGreenSheet(int id);
    }
}
