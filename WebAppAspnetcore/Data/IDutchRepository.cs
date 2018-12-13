using System.Collections.Generic;
using WebAppAspnetcore.Data.Entities;

namespace WebAppAspnetcore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);


        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrdersById(int id);

        bool SaveAll();
        void AddEntity(object model);

    }
}