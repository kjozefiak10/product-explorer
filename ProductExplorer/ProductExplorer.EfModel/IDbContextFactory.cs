using Microsoft.EntityFrameworkCore;

namespace ProductExplorer.EfModel
{
    public interface IDbContextFactory<T> where T : DbContext
    {
        T GetContext();
    }
}
