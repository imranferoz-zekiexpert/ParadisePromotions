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
    public class InvoiceDetailsService : IInvoiceDetailsService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public InvoiceDetailsService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            if (invoiceDetail != null)
            {
               
                await _unitOfWork.InvoiceDetails.Insert(invoiceDetail);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteInvoiceDetail(int id)
        {
            if (id > 0)
            {
                var invoiceDetail = await _unitOfWork.InvoiceDetails.GetById(id);
                if (invoiceDetail != null)
                {
                    _unitOfWork.InvoiceDetails.Delete(invoiceDetail);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetAllInvoiceDetails()
        {
            var invoiceDetails = await _unitOfWork.InvoiceDetails.GetAll();
            return invoiceDetails; ;
        }

        public async Task<InvoiceDetail> GetInvoiceDetailById(int id)
        {
            if (id > 0)
            {
                var invoiceDetail = await _unitOfWork.InvoiceDetails.GetById(id);
                if (invoiceDetail != null)
                {
                    return invoiceDetail;
                }
            }
            return null;
        }

        public async Task<bool> UpdateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            if (invoiceDetail == null)
            {
                return false;
            }

            var existingInvoiceDetail = await _unitOfWork.InvoiceDetails.GetById(invoiceDetail.ID);
            if (existingInvoiceDetail == null)
            {
                return false;
            }

            // Update the properties of the existing invoiceDetail
            existingInvoiceDetail.Invoice_ID = invoiceDetail.Invoice_ID;
            existingInvoiceDetail.Product = invoiceDetail.Product;
            existingInvoiceDetail.Price = invoiceDetail.Price;
            existingInvoiceDetail.Color1 = invoiceDetail.Color1;
            existingInvoiceDetail.Color_Type1 = invoiceDetail.Color_Type1;
            existingInvoiceDetail.Color2 = invoiceDetail.Color2;
            existingInvoiceDetail.Color_Type2 = invoiceDetail.Color_Type2;
            existingInvoiceDetail.Color3 = invoiceDetail.Color3;
            existingInvoiceDetail.Color_Type3 = invoiceDetail.Color_Type3;
            existingInvoiceDetail.Color4 = invoiceDetail.Color4;
            existingInvoiceDetail.Color_Type4 = invoiceDetail.Color_Type4;
            existingInvoiceDetail.Color5 = invoiceDetail.Color5;
            existingInvoiceDetail.Color_Type5 = invoiceDetail.Color_Type5;
            existingInvoiceDetail.Cost = invoiceDetail.Cost;
            existingInvoiceDetail.Par_Value = invoiceDetail.Par_Value;
            existingInvoiceDetail.Quantity = invoiceDetail.Quantity;
            existingInvoiceDetail.Shipping = invoiceDetail.Shipping;
            existingInvoiceDetail.Logo = invoiceDetail.Logo;
            existingInvoiceDetail.Real_Pro_Cost = invoiceDetail.Real_Pro_Cost;
            existingInvoiceDetail.Total_Comm = invoiceDetail.Total_Comm;
            existingInvoiceDetail.Fronter_Comm = invoiceDetail.Fronter_Comm;
            existingInvoiceDetail.Closer_Comm = invoiceDetail.Closer_Comm;
            existingInvoiceDetail.AdCopy = invoiceDetail.AdCopy;
            existingInvoiceDetail.PreviousQtyEntered = invoiceDetail.PreviousQtyEntered;
            existingInvoiceDetail.Upsize_Ts = invoiceDetail.Upsize_Ts;

            // Perform the update in the database
            _unitOfWork.InvoiceDetails.Update(existingInvoiceDetail);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }


    }
}
