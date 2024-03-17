using Bleems_Task.Models;

namespace Bleems_Task.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IRepository<ProductCategory> _categoryRepository;
        public IRepository<ProductCategory> CategoryRepository => _categoryRepository ??= new Repository<ProductCategory>(_context);

        private IRepository<Product> _productRepository;
        public IRepository<Product> ProductRepository => _productRepository ??= new Repository<Product>(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
