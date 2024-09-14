using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetailReport(DateTime startDate, DateTime endDate)
        {
            return OrderDetailDAO.Instance.GetOrderDetailReport(startDate, endDate);
        }

        public IEnumerable<OrderDetail> GetOrders()
        {
            return OrderDetailDAO.Instance.GetOrderDetails();
        }

        public IEnumerable<OrderDetail> GetOrdersByOrderId(int orderId)
        {
            return OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderId);
        }
    }
}
