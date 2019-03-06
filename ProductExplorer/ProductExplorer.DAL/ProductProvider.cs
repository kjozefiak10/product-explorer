using Microsoft.EntityFrameworkCore;
using ProductExplorer.EfModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductExplorer.DAL
{
    public class ProductProvider : IProductProvider
    {
        private readonly IDbContextFactory<ProductDbContext> _contextFactory;

        public ProductProvider(IDbContextFactory<ProductDbContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                Product product = await context.GetProduct(id);
                return MapProductToDto(product);
            }
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            using (var context = _contextFactory.GetContext())
            {
                var products = await context.Product.ToListAsync();
                return products.Select(MapProductToDto);
            }
        }

        public async Task<ProductModel> AddProduct(string name, string description)
        {
            using (var context = _contextFactory.GetContext())
            {
                Product product = new Product
                {
                    Name = name,
                    Description = description
                };

                context.Product.Add(product);

                await context.SaveChangesAsync();

                return MapProductToDto(product);
            }
        }

        public async Task UpdateProduct(int id, string name, string description)
        {
            using (var context = _contextFactory.GetContext())
            {
                Product product = await context.GetProduct(id);

                product.Name = name;
                product.Description = description;
                product.ModificationDate = DateTime.Now;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                Product product = await context.GetProduct(id);

                context.Product.Remove(product);

                await context.SaveChangesAsync();
            }
        }

        private ProductModel MapProductToDto(Product product)
            => new ProductModel(product.Id, product.Name, product.Description, product.AddedDate, product.ModificationDate);
    }
}
