using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order order, List<Product> products)
        {
            OrderDAO.Instance.addOrder(order, products);
        }

        public void DeleteOrder(int orderId)
        {
            OrderDAO.Instance.deleteOrder(orderId);
        }

        public Order GetOrderById(int orderId)
        {
            return OrderDAO.Instance.GetOrderById(orderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return OrderDAO.Instance.GetOrders();
        }

        public IEnumerable<Order> GetOrdersByMemberId(int memberId)
        {
            return OrderDAO.Instance.GetOrderByMemberId(memberId);
        }

        public void UpdateOrder(Order order)
        {
            OrderDAO.Instance.UpdateOrder(order);
        }
    }
}
