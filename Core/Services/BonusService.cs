using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadisePromotions.Core.Services
{
    public class BonusService : IBonusService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public BonusService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateBonus(Bonus bonus)
        {
            if (bonus != null)
            {
               
                await _unitOfWork.Bonus.Insert(bonus);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteBonus(int id)
        {
            if (id > 0)
            {
                var bonus = await _unitOfWork.Bonus.GetById(id);
                if (bonus != null)
                {
                    _unitOfWork.Bonus.Delete(bonus);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Bonus>> GetAllBonus()
        {
            var bonuss = await _unitOfWork.Bonus.GetAll();
            return bonuss; ;
        }

        public async Task<Bonus> GetBonusById(int id)
        {
            if (id > 0)
            {
                var bonus = await _unitOfWork.Bonus.GetById(id);
                if (bonus != null)
                {
                    return bonus;
                }
            }
            return null;
        }

        public async Task<bool> UpdateBonus(Bonus bonus)
        {
            if (bonus == null)
            {
                return false;
            }

            // Fetch the existing bonus item by ID
            var existingBonus = await _unitOfWork.Bonus.GetById(bonus.ID);
            if (existingBonus == null)
            {
                return false;
            }

            // Update the properties of the existing bonus with the new values
            existingBonus.Employee = bonus.Employee; // Updated
            existingBonus.Date = bonus.Date; // Updated
            existingBonus.Bonus_Amount = bonus.Bonus_Amount; // Updated

            // Perform the update in the database
            _unitOfWork.Bonus.Update(existingBonus);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }

    }
}
