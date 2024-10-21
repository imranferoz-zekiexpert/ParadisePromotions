using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Models.ReportsModels;

namespace ParadisePromotions.Core.Services.ReportsServices
{
    public class BuyingHistoryService : IBuyingHistoryService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public BuyingHistoryService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateBuyingHistory(BuyingHistory buyingHistory)
        {
            if (buyingHistory != null)
            {

                await _unitOfWork.BuyingHistory.Insert(buyingHistory);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteBuyingHistory(int id)
        {
            if (id > 0)
            {
                var buyingHistory = await _unitOfWork.BuyingHistory.GetById(id);
                if (buyingHistory != null)
                {
                    _unitOfWork.BuyingHistory.Delete(buyingHistory);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<BuyingHistory>> GetAllBuyingHistory()
        {
            var buyingHistorys = await _unitOfWork.BuyingHistory.GetAll();
            return buyingHistorys; ;
        }

        public async Task<BuyingHistory> GetBuyingHistoryById(int id)
        {
            if (id > 0)
            {
                var buyingHistory = await _unitOfWork.BuyingHistory.GetById(id);
                if (buyingHistory != null)
                {
                    return buyingHistory;
                }
            }
            return null;
        }

        public async Task<bool> UpdateBuyingHistory(BuyingHistory buyingHistory)
        {
            if (buyingHistory == null)
            {
                return false;
            }

            // Fetch the existing buyingHistory item by ID
            var existingBuyingHistory = await _unitOfWork.BuyingHistory.GetById(buyingHistory.id);
            if (existingBuyingHistory == null)
            {
                return false;
            }

            // Update the properties of the existing buyingHistory with the new values
            existingBuyingHistory.Fronter = buyingHistory.Fronter;
            existingBuyingHistory.Closer = buyingHistory.Closer;
            existingBuyingHistory.SGI_Type_Date = buyingHistory.SGI_Type_Date;
            existingBuyingHistory.Customer_ID = buyingHistory.Customer_ID;
            existingBuyingHistory.Sale_Date = buyingHistory.Sale_Date;
            existingBuyingHistory.Invoice_ID = buyingHistory.Invoice_ID;
            existingBuyingHistory.Total = buyingHistory.Total;
            existingBuyingHistory.Card_Number = buyingHistory.Card_Number;
            existingBuyingHistory.CreditCardLastFourDigits = buyingHistory.CreditCardLastFourDigits;

            // Perform the update in the database
            _unitOfWork.BuyingHistory.Update(existingBuyingHistory);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }

    }
}
