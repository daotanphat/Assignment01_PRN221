using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                var myStoreDB = new FStoreContext();
                orderDetails = myStoreDB.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                var myStoreDB = new FStoreContext();
                Order order = myStoreDB.Orders.SingleOrDefault(m => m.OrderId == orderId);
                if (order == null)
                {
                    throw new Exception("Order not found!");
                }
                orderDetails = myStoreDB.OrderDetails
                    .Include(od => od.Product)
                    .Where(m => m.OrderId == orderId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public IEnumerable<OrderDetail> GetOrderDetailReport(DateTime startDate, DateTime endDate)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            try
            {
                var myStoreDB = new FStoreContext();

                // Normalize the dates
                startDate = startDate.Date;
                endDate = endDate.Date.AddDays(1).AddTicks(-1);
                orderDetails = myStoreDB.OrderDetails
                    .Include(od => od.Product)
                    .Include(od => od.Order)
                    .Where(od => od.Order.ShippedDate >= startDate && od.Order.ShippedDate <= endDate)
                    .OrderByDescending(od => od.Order.ShippedDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
    }
}
