using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrders();
        IEnumerable<OrderDetail> GetOrdersByOrderId(int orderId);
        IEnumerable<OrderDetail> GetOrderDetailReport(DateTime startDate, DateTime endDate);
    }
}
