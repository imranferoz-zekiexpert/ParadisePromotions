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
               leads.CreatedDate = DateTime.Now;
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
            if (leads.AssignedTo != null)
            {
                existingLeads.AssignedTo = leads.AssignedTo;
                existingLeads.AssignDate= DateTime.Now;
            }           
            existingLeads.CycleId = leads.CycleId;
            existingLeads.TimeZoneId = leads.TimeZoneId;
            existingLeads.CallBackDate = leads.CallBackDate;
            existingLeads.LastDispositionId = leads.LastDispositionId;
            existingLeads.DispDateTime = leads.DispDateTime;
            existingLeads.LastSaleDate = leads.LastSaleDate;
            existingLeads.UpdatedDate = DateTime.Now;
            existingLeads.UpdatedBy = leads.UpdatedBy;


            // Perform the update in the database
            _unitOfWork.Leads.Update(existingLeads);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }
        public async Task<IEnumerable<Lead>> GetLeadsCount(LeadsFilter filter)
        {
            // Parse the startDate and endDate strings to DateTime
            if (!DateTime.TryParse(filter.StartDate, out var parsedStartDate) ||
                !DateTime.TryParse(filter.EndDate, out var parsedEndDate))
            {
                throw new ArgumentException("Invalid date format for startDate or endDate.");
            }

            // Fetch all BlankSales
            var leads = await _unitOfWork.Leads.GetAll();
            parsedEndDate = parsedEndDate.Date.AddDays(1);
            // Filter the sales
            var filteredLeads = leads.Where(s => (s.AssignedTo.ToString() == filter.UserID.ToString() ||
                                                  s.CreatedBy.ToString() == filter.UserID.ToString()) &&
                                                      (s.CreatedDate >= parsedStartDate && s.CreatedDate < parsedEndDate));

            return filteredLeads;
        }

    }
}
