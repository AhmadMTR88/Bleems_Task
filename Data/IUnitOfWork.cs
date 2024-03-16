namespace Bleems_Task.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IProductCategoryRepository ProductCategories { get; }
        int Complete();
    }
}