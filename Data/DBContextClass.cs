
using Microsoft.EntityFrameworkCore;
using ParadisePromotions.Core.Models;

namespace ParadisePromotions.Data
{
    public class DBContextClass : DbContext
    {
        public DBContextClass(DbContextOptions<DBContextClass> options) : base(options) { }

    DbSet<UserModel> users { get; set; } = null!;
    }

}
