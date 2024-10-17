namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext _Context;

      

        public EFStoreRepository(StoreDbContext sdc)
        {
            _Context = sdc;
        }
        public IQueryable<Product> products => _Context.Products;

        //public IQueryable<Product> products => throw new NotImplementedException();

        //IQueryable<Product> IStoreRepository.products => throw new NotImplementedException();

        //public IQueryable<Product> products => throw new NotImplementedException();
    }
}
