namespace ParadisePromotions.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        int Save();
    }
}
