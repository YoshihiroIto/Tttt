using System.Threading.Tasks;

namespace Tttt.Foundation.Interface
{
    public interface IRepository<T>
    {
        Task SaveAsync(T obj);
        Task<T> LoadAsync();
    }
}