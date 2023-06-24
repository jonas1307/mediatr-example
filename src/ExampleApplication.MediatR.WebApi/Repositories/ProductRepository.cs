using ExampleApplication.MediatR.WebApi.Entities;

namespace ExampleApplication.MediatR.WebApi.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private static readonly Dictionary<Guid, Product> Products = new();

        public void PopulateProducts()
        {
            var id = Guid.NewGuid();
            Products.Add(id, new Product { Id = id, Name = "Pen", Price = 3.45m });

            id = Guid.NewGuid();
            Products.Add(id, new Product { Id = id, Name = "Notebook", Price = 7.65m });

            id = Guid.NewGuid();
            Products.Add(id, new Product { Id = id, Name = "Eraser", Price = 1.20m });
        }

        public ProductRepository()
        {
            PopulateProducts();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.Run(() => Products.Values.ToList());
        }

        public async Task<Product?> Get(Guid id)
        {
            return await Task.Run(() => Products.GetValueOrDefault(id));
        }

        public async Task Insert(Product Product)
        {
            await Task.Run(() => Products.Add(Product.Id, Product));
        }

        public async Task Update(Product Product)
        {
            await Task.Run(() =>
            {
                Products.Remove(Product.Id);
                Products.Add(Product.Id, Product);
            });
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() => Products.Remove(id));
        }
    }
}
