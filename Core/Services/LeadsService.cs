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
    public class LeadsService : ILeadsService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public LeadsService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateLeads(Lead leads)
        {
            if (leads != null)
            {
               
                await _unitOfWork.Leads.Insert(leads);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteLeads(int id)
        {
            if (id > 0)
            {
                var leads = await _unitOfWork.Leads.GetById(id);
                if (leads != null)
                {
                    _unitOfWork.Leads.Delete(leads);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Lead>> GetAllLeads()
        {
            var leadss = await _unitOfWork.Leads.GetAll();
            return leadss; ;
        }

        public async Task<Lead> GetLeadsById(int id)
        {
            if (id > 0)
            {
                var leads = await _unitOfWork.Leads.GetById(id);
                if (leads != null)
                {
                    return leads;
                }
            }
            return null;
        }

        public async Task<bool> UpdateLeads(Lead leads)
        {
            if (leads == null)
            {
                return false;
            }

            // Fetch the existing leads item by ID
            var existingLeads = await _unitOfWork.Leads.GetById(leads.Id);
            if (existingLeads == null)
            {
                return false;
            }

            // Update the properties of the existing leads with the new values
            existingLeads.CompanyName = leads.CompanyName;
            existingLeads.Comments = leads.Comments;
            existingLeads.Phone1 = leads.Phone1;
            existingLeads.CustomerId = leads.CustomerId;
            existingLeads.CycleId = leads.CycleId;
            existingLeads.TimeZoneId = leads.TimeZoneId;
            existingLeads.CallBackDate = leads.CallBackDate;
            existingLeads.LastDispositionId = leads.LastDispositionId;
            existingLeads.DispDateTime = leads.DispDateTime;
            existingLeads.LastSaleDate = leads.LastSaleDate;
            existingLeads.UpdatedDate = DateTime.Now;

            // Perform the update in the database
            _unitOfWork.Leads.Update(existingLeads);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }


    }
}
