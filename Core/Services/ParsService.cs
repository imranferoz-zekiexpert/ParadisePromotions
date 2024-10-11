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
    public class ParsService : IParsService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public ParsService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreatePars(Pars pars)
        {
            if (pars != null)
            {
               
                await _unitOfWork.Pars.Insert(pars);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeletePars(int id)
        {
            if (id > 0)
            {
                var pars = await _unitOfWork.Pars.GetById(id);
                if (pars != null)
                {
                    _unitOfWork.Pars.Delete(pars);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Pars>> GetAllPars()
        {
            var parss = await _unitOfWork.Pars.GetAll();
            return parss; ;
        }

        public async Task<Pars> GetParsById(int id)
        {
            if (id > 0)
            {
                var pars = await _unitOfWork.Pars.GetById(id);
                if (pars != null)
                {
                    return pars;
                }
            }
            return null;
        }

        public async Task<bool> UpdatePars(Pars pars)
        {
            if (pars == null)
            {
                return false;
            }

            // Fetch the existing pars item by ID
            var existingPars = await _unitOfWork.Pars.GetById(pars.ID);
            if (existingPars == null)
            {
                return false;
            }

            // Update the properties of the existing pars with the new values
            existingPars.Product = pars.Product;
            existingPars.Quantity = pars.Quantity;
            existingPars.Par = pars.Par;
            existingPars.Cost = pars.Cost;
            existingPars.CODShipping = pars.CODShipping;
            existingPars.NonCODShipping = pars.NonCODShipping;

            // Perform the update in the database
            _unitOfWork.Pars.Update(existingPars);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }

    }
}
