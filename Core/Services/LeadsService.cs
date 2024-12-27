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

        public async Task<bool> UpdateLeads(IEnumerable<Lead> leads)
        {
            if (leads == null || !leads.Any())
            {
                return false;
            }

            foreach (var lead in leads)
            {
                // Fetch the existing lead item by ID
                var existingLead = await _unitOfWork.Leads.GetById(lead.Id);
                if (existingLead == null)
                {
                    continue; // Skip if the lead does not exist
                }

                // Update the properties of the existing lead with the new values
                existingLead.CompanyName = lead.CompanyName;
                existingLead.Comments = lead.Comments;
                existingLead.Phone1 = lead.Phone1;
                existingLead.CustomerId = lead.CustomerId;

                if (lead.AssignedTo != null)
                {
                    existingLead.AssignedTo = lead.AssignedTo;
                    existingLead.AssignDate = DateTime.Now;
                }

                existingLead.CycleId = lead.CycleId;
                existingLead.TimeZoneId = lead.TimeZoneId;
                existingLead.CallBackDate = lead.CallBackDate;
                existingLead.LastDispositionId = lead.LastDispositionId;
                existingLead.DispDateTime = lead.DispDateTime;
                existingLead.LastSaleDate = lead.LastSaleDate;
                existingLead.UpdatedDate = DateTime.Now;
                existingLead.UpdatedBy = lead.UpdatedBy;

                // Perform the update in the database
                _unitOfWork.Leads.Update(existingLead);
            }

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
