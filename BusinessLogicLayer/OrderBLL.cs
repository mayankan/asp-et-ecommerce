using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class OrderBLL
    {
        //DB Context
        etEcomEntities dbcontext = new etEcomEntities();
        //Instantiates the DataBase model from edmx file in this Solution.
        /// <summary>
        /// Gets all the Active Orders in The Database with IsDeleted Column set to false
        /// </summary>
        /// <returns>Collection Of Order Communication Layer Class.</returns>
        public Collection<OrderCL> getActiveOrders()
        {
            Collection<OrderCL> activeOrders = new Collection<OrderCL>();
            IQueryable<Order> query = from x in dbcontext.Orders where x.StatusId == 0 && x.IsDeleted == false select x;
            foreach (Order item in query)
            {
                activeOrders.Add(new OrderCL
                    {
                        addressId = item.AddressId,
                        cartId = item.CartId,
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        description = item.Description,
                        id = item.Id,
                        isDeleted = item.IsDeleted,
                        shippingCharge = item.ShippingCharge.ToString(),
                        statusId = item.StatusId,
                        taxAmount = item.TaxAmount,
                        totalAmount = item.TotalAmount,
                        orderNumber=item.OrderNumber,
                    });
            }
            return activeOrders;
        }
        /// <summary>
        /// Gets all the Pending Orders in The Database with IsDeleted Column set to false
        /// </summary>
        /// <returns>Collection Of Pending Communication Layer Class.</returns>
        public Collection<OrderCL> getPendingOrders()
        {
            Collection<OrderCL> pendingOrders = new Collection<OrderCL>();
            IQueryable<Order> query = from x in dbcontext.Orders where x.StatusId == 1 && x.IsDeleted == false select x;
            foreach (Order item in query)
            {
                pendingOrders.Add(new OrderCL
                {
                    addressId = item.AddressId,
                    cartId = item.CartId,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    description = item.Description,
                    id = item.Id,
                    isDeleted = item.IsDeleted,
                    shippingCharge = item.ShippingCharge.ToString(),
                    statusId = item.StatusId,
                    taxAmount = item.TaxAmount,
                    totalAmount = item.TotalAmount,
                    orderNumber=item.OrderNumber,
                });
            }
            return pendingOrders;
        }
        /// <summary>
        /// Gets all the Completed Orders in The Database with IsDeleted Column set to false
        /// </summary>
        /// <returns>Collection Of Completed Communication Layer Class.</returns>
        public Collection<OrderCL> getCompletedOrders()
        {
            Collection<OrderCL> completedOrders = new Collection<OrderCL>();
            IQueryable<Order> query = from x in dbcontext.Orders where x.StatusId == 2 && x.IsDeleted == false select x;
            foreach (Order item in query)
            {
                completedOrders.Add(new OrderCL
                {
                    addressId = item.AddressId,
                    cartId = item.CartId,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    description = item.Description,
                    id = item.Id,
                    isDeleted = item.IsDeleted,
                    shippingCharge = item.ShippingCharge.ToString(),
                    statusId = item.StatusId,
                    taxAmount = item.TaxAmount,
                    totalAmount = item.TotalAmount,
                    orderNumber=item.OrderNumber,
                });
            }
            return completedOrders;
        }
        /// <summary>
        /// Fetchs the Order Data by providing Order Id.
        /// </summary>
        /// <param name="orderId">Order Id of the product to be fetched.</param>
        /// <returns>Order CL of the orderId passed to be fetched.</returns>
        public OrderCL getOrderById(int orderId)
        {
            Order query = (from x in dbcontext.Orders where x.Id == orderId select x).FirstOrDefault();
            OrderCL orderCL = new OrderCL()
            {
                addressId = query.AddressId,
                cartId = query.CartId,
                dateModified = query.DateModified,
                dateCreated = query.DateCreated,
                description = query.Description,
                isDeleted = query.IsDeleted,
                id = query.Id,
                shippingCharge = query.ShippingCharge.ToString(),
                statusId = query.StatusId,
                totalAmount = query.TotalAmount,
                taxAmount = query.TaxAmount,
                orderNumber=query.OrderNumber,
            };
            return orderCL;
        }
        /// <summary>
        /// Updates the Order Data with respect to the desired shipping details.
        /// </summary>
        /// <param name="orderCL">OrderCL class containing Order Description and Status</param>
        /// <returns>OrderCL class returning all the fields in the updated Order.</returns>
        public OrderCL updateShippingDetails(OrderCL orderCL)
        {
            Order query = (from x in dbcontext.Orders where x.Id == orderCL.id && x.IsDeleted == false select x).FirstOrDefault();
            query.Description=orderCL.description;
            query.StatusId = orderCL.statusId;
            dbcontext.SaveChanges();
            OrderCL newOrderCL = new OrderCL()
            {
                id = query.Id,
                addressId = query.AddressId,
                cartId = query.CartId,
                dateCreated = query.DateCreated,
                dateModified = query.DateModified,
                description = query.Description,
                isDeleted = query.IsDeleted,
                shippingCharge = query.ShippingCharge.ToString(),
                statusId = query.StatusId,
                taxAmount = query.TaxAmount,
                totalAmount = query.TotalAmount,
                orderNumber=query.OrderNumber,
            };
            return newOrderCL;
        }
        /// <summary>
        /// Fetchs the all the orders containing Order CL class by Cart Id.
        /// </summary>
        /// <param name="cartId">Cart Id provided to get Order CL class for it.</param>
        /// <returns>Order CL class having orderId provided.</returns>
        public OrderCL getOrderByCartId(int cartId)
        {
            Order query = (from x in dbcontext.Orders where x.CartId == cartId select x).FirstOrDefault();
            OrderCL orderCL = new OrderCL()
            {
                addressId = query.AddressId,
                cartId = query.CartId,
                dateCreated = query.DateCreated,
                dateModified = query.DateModified,
                description = query.Description,
                id = query.Id,
                isDeleted = query.IsDeleted,
                shippingCharge = query.ShippingCharge.ToString(),
                statusId = query.StatusId,
                taxAmount = query.TaxAmount,
                totalAmount = query.TotalAmount,
                orderNumber=query.OrderNumber,
            };
            return orderCL;
        }
    }
}
