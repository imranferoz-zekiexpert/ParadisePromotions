using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParadisePromotions.Core.Services
{
    public class InventoryService : IInventoryService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public InventoryService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> CreateInventory(Inventory inventory)
        {
            if (inventory != null)
            {
               
                await _unitOfWork.Inventory.Insert(inventory);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteInventory(int id)
        {
            if (id > 0)
            {
                var inventory = await _unitOfWork.Inventory.GetById(id);
                if (inventory != null)
                {
                    _unitOfWork.Inventory.Delete(inventory);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventory()
        {
            var inventorys = await _unitOfWork.Inventory.GetAll();
            return inventorys; ;
        }

        public async Task<Inventory> GetInventoryById(int id)
        {
            if (id > 0)
            {
                var inventory = await _unitOfWork.Inventory.GetById(id);
                if (inventory != null)
                {
                    return inventory;
                }
            }
            return null;
        }

        public async Task<bool> UpdateInventory(Inventory inventory)
        {
            if (inventory == null)
            {
                return false;
            }

            // Fetch the existing inventory item by ID
            var existingInventory = await _unitOfWork.Inventory.GetById(inventory.ID);
            if (existingInventory == null)
            {
                return false;
            }

            // Update the properties of the existing inventory with the new values
            existingInventory.Product = inventory.Product;
            existingInventory.Color = inventory.Color;
            existingInventory.Quantity = inventory.Quantity;
            existingInventory.AvailableQty = inventory.AvailableQty;
            existingInventory.ViewableProduct = inventory.ViewableProduct;
            existingInventory.Upsize_TS = inventory.Upsize_TS;

            // Perform the update in the database
            _unitOfWork.Inventory.Update(existingInventory);

            // Save the changes
            var result = _unitOfWork.Save();
            return result > 0;
        }
    }
}
