namespace ParadisePromotions.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        IProductsRepository Products { get; }
        int Save();
    }
}
