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
    public class CustomersService : ICustomersService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public CustomersService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
               
                await _unitOfWork.Customers.Insert(customer);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            if (id > 0)
            {
                var customer = await _unitOfWork.Customers.GetById(id);
                if (customer != null)
                {
                    _unitOfWork.Customers.Delete(customer);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _unitOfWork.Customers.GetAll();
            return customers; ;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            if (id > 0)
            {
                var customer = await _unitOfWork.Customers.GetById(id);
                if (customer != null)
                {
                    return customer;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }

            var existingCustomer = await _unitOfWork.Customers.GetById(customer.ID);
            if (existingCustomer == null)
            {
                return false;
            }

            // Update the properties of the existing customer
            existingCustomer.Old_ID = customer.Old_ID;
            existingCustomer.Company_Name = customer.Company_Name;
            existingCustomer.First_Name = customer.First_Name;
            existingCustomer.Last_Name = customer.Last_Name;
            existingCustomer.Address = customer.Address;
            existingCustomer.Address2 = customer.Address2;
            existingCustomer.City = customer.City;
            existingCustomer.State = customer.State;
            existingCustomer.Zip = customer.Zip;
            existingCustomer.Phone1 = customer.Phone1;
            existingCustomer.Phone1_Ext = customer.Phone1_Ext;
            existingCustomer.Phone2 = customer.Phone2;
            existingCustomer.Phone2_Ext = customer.Phone2_Ext;
            existingCustomer.Cycle = customer.Cycle;
            existingCustomer.Input_Date = customer.Input_Date;
            existingCustomer.Last_Closer = customer.Last_Closer;
            existingCustomer.Last_Sale_Date = customer.Last_Sale_Date;
            existingCustomer.Last_Closer_ID = customer.Last_Closer_ID;
            existingCustomer.Invoice_Count = customer.Invoice_Count;
            existingCustomer.NextAssignedSalesPersonID = customer.NextAssignedSalesPersonID;
            existingCustomer.SpecialNotes = customer.SpecialNotes;
            existingCustomer.Assign = customer.Assign;
            existingCustomer.ImportDate = customer.ImportDate;
            existingCustomer.InternalNotes = customer.InternalNotes;
            existingCustomer.Upsize_Ts = customer.Upsize_Ts;
            existingCustomer.NextAssignmentDate = customer.NextAssignmentDate;
            existingCustomer.NewLead = customer.NewLead;
            existingCustomer.PreviousCloserID = customer.PreviousCloserID;
            existingCustomer.NextCloserID = customer.NextCloserID;
            existingCustomer.CallListLastCloserID = customer.CallListLastCloserID;
            existingCustomer.SamplePack = customer.SamplePack;

            // Perform the update in the database
            _unitOfWork.Customers.Update(existingCustomer);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }



    }
}
