namespace GestionITM.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodoAsync();
        Task AgregarAsync(T entidad);
    }
}