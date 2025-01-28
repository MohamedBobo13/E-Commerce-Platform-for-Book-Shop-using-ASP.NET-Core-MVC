namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        // Repository for Category-related data operations
        public ICategoryRepository Category { get; }

        // Repository for Product-related data operations
        public IProductRepository Product { get; }

        // Repository for Company-related data operations
        public ICompanyRepository Company { get; }

        // Repository for ShoppingCart-related data operations
        public IShoppingCartRepository ShoppingCart { get; }

        // Repository for ApplicationUser-related data operations
        public IApplicationUserRepository ApplicationUser { get; }

        // Repository for OrderDetail-related data operations
        public IOrderDetailRepository OrderDetail { get; }

        // Repository for OrderHeader-related data operations
        public IOrderHeaderRepository OrderHeader { get; }

        public IProductImageRepository ProductImage { get; }

        // Method to save all changes made in the current transaction
        void Save();
    }
}
