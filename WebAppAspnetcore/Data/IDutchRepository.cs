using System.Collections.Generic;
using WebAppAspnetcore.Data.Entities;

namespace WebAppAspnetcore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);


        IEnumerable<Order> GetAllOrders();
        Order GetAllOrdersById(int id);

        bool SaveChanges();
    }
}