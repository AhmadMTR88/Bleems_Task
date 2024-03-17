using Bleems_Task.Models;

namespace Bleems_Task.Data
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<ProductCategory> CategoryRepository { get; }
        void Save();
    }
}
