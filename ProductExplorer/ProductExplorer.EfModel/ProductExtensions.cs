using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ProductExplorer.EfModel
{
    public partial class ProductDbContext 
    {
        public async Task<Product> GetProduct(int id)
        {
            Product product = await Product.SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new ArgumentException($"Product id: {id} not found.");

            return product;
        }
    }
}
