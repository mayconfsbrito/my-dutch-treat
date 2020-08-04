using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        Order GetOrderById(string username, int id);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);

        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        void AddEntity(object model);
    }
}