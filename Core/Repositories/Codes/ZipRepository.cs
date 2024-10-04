using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Models.Codes;
using ParadisePromotions.Data;

namespace ParadisePromotions.Core.Repositories.Codes
{
    public class ZipRepository : GenericRepository<Zips>, IZipRepository
    {
        public ZipRepository(DBContextClass dbContext) : base(dbContext) { }
    }
}