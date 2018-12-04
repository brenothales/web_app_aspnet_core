using System.Collections.Generic;
using WebAppAspnetcore.Data.Entities;

namespace WebAppAspnetcore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveChanges();
    }
}