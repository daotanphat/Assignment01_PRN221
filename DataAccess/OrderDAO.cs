using BusinessObject;
using BusinessObject.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                var myStoreDB = new FStoreContext();
                orders = myStoreDB.Orders.Include(o => o.Member).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order GetOrderById(int id)
        {
            Order order = new Order();
            try
            {
                var myStoreDB = new FStoreContext();
                order = myStoreDB.Orders.SingleOrDefault(m => m.OrderId == id);
                if (order == null)
                {
                    throw new Exception("Order not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public List<Order> GetOrderByMemberId(int memberId)
        {
            List<Order> orders = new List<Order>();
            try
            {
                var myStoreDB = new FStoreContext();
                orders = myStoreDB.Orders
                    .Where(o => o.MemberId == memberId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public void addOrder(Order order, List<Product> products)
        {
            try
            {
                var myStoreDB = new FStoreContext();
                using (var transaction = myStoreDB.Database.BeginTransaction())
                {
                    try
                    {
                        //save order
                        myStoreDB.Orders.Add(order);
                        myStoreDB.SaveChanges();

                        foreach (var item in products)
                        {
                            OrderDetail detail = new OrderDetail
                            {
                                OrderId = order.OrderId,
                                ProductId = item.ProductId,
                                UnitPrice = item.UnitPrice,
                                Quantity = 1,
                                Discount = 10
                            };
                            myStoreDB.OrderDetails.Add(detail);
                        }
                        myStoreDB.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                using (var myStoreDB = new FStoreContext())
                {
                    using (var transaction = myStoreDB.Database.BeginTransaction())
                    {
                        try
                        {
                            Order order1 = GetOrderById(order.OrderId);
                            if (order1 == null)
                            {
                                throw new Exception("Order is not exist");
                            }
                            myStoreDB.Entry<Order>(order).State = EntityState.Modified;
                            myStoreDB.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deleteOrder(int id)
        {
            try
            {
                using (var myStoreDB = new FStoreContext())
                {
                    using (var transaction = myStoreDB.Database.BeginTransaction())
                    {
                        try
                        {
                            var order = myStoreDB.Orders
                            .Include(o => o.OrderDetails)
                            .FirstOrDefault(o => o.OrderId == id);
                            if (order == null)
                            {
                                throw new Exception("Order does not exist");
                            }
                            myStoreDB.OrderDetails.RemoveRange(order.OrderDetails);
                            myStoreDB.Orders.Remove(order);
                            myStoreDB.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
