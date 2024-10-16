using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Core.Services
{
    public class ChargeBackService : IChargeBackService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public ChargeBackService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateChargeBack(ChargeBack chargeBack)
        {
            if (chargeBack != null)
            {
               
                await _unitOfWork.ChargeBack.Insert(chargeBack);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteChargeBack(int id)
        {
            if (id > 0)
            {
                var chargeBack = await _unitOfWork.ChargeBack.GetById(id);
                if (chargeBack != null)
                {
                    _unitOfWork.ChargeBack.Delete(chargeBack);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ChargeBack>> GetAllChargeBack()
        {
            var chargeBacks = await _unitOfWork.ChargeBack.GetAll();
            return chargeBacks; ;
        }

        public async Task<ChargeBack> GetChargeBackById(int id)
        {
            if (id > 0)
            {
                var chargeBack = await _unitOfWork.ChargeBack.GetById(id);
                if (chargeBack != null)
                {
                    return chargeBack;
                }
            }
            return null;
        }

        public async Task<bool> UpdateChargeBack(ChargeBack chargeBack)
        {
            if (chargeBack == null)
            {
                return false;
            }

            // Fetch the existing chargeBack item by ID
            var existingChargeBack = await _unitOfWork.ChargeBack.GetById(chargeBack.ID);
            if (existingChargeBack == null)
            {
                return false;
            }

            // Update the properties of the existing chargeBack with the new values
            existingChargeBack.Invoice_ID = chargeBack.Invoice_ID;
            existingChargeBack.Employee = chargeBack.Employee;
            existingChargeBack.Amount = chargeBack.Amount;
            existingChargeBack.Date = chargeBack.Date;
            existingChargeBack.Company_Name = chargeBack.Company_Name;

            // Perform the update in the database
            _unitOfWork.ChargeBack.Update(existingChargeBack);

            // Save the changes
            var result =  _unitOfWork.Save();
            return result > 0;
        }

    }
}
