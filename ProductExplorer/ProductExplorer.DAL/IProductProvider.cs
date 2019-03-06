using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductExplorer.DAL
{
    public interface IProductProvider
    {
        Task<ProductModel> AddProduct(string name, string description);
        Task DeleteProduct(int id);
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int id);
        Task UpdateProduct(int id, string name, string description);
    }
}