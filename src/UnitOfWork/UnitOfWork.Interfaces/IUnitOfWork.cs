namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create(bool hasTransaction = false);
    }
}
