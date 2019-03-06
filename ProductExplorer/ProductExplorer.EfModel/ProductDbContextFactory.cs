using System;
using System.Collections.Generic;
using System.Text;

namespace ProductExplorer.EfModel
{
    public class ProductDbContextFactory : IDbContextFactory<ProductDbContext>
    {
        private readonly Func<ProductDbContext> _createDbContext;

        public ProductDbContextFactory(Func<ProductDbContext> dbContextFunc)
        {
            _createDbContext = dbContextFunc;
        }

        public ProductDbContext GetContext()
        {
            return _createDbContext();
        }
    }
}
