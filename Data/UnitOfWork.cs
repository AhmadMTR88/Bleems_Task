using Bleems_Task.Models;

namespace Bleems_Task.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ProductRepository = new Repository<Product>(_context);
            CategoryRepository = new Repository<ProductCategory>(_context);
        }

        public IRepository<Product> ProductRepository { get; }
        public IRepository<ProductCategory> CategoryRepository { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
