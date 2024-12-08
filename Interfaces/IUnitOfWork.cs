namespace ProjetDotNet.Interfaces
{
    public interface IUnitOfWork
    {
        
        IRepository GetRepository<T>() where T : class;
    
}
}
