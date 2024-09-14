using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrdersByMemberId(int memberId);
        void CreateOrder(Order order, List<Product> products);
        Order GetOrderById(int orderId);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
