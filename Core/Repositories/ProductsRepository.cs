﻿using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Models;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories
{
    public class ProductsRepository :GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(DBContextClass dbContext):base(dbContext) { }
    }
}