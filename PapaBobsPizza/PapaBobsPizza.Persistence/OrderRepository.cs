using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsPizza.DTO;
using System.Data;

namespace PapaBobsPizza.Persistence
{
    public class OrderRepository
    {
        public static List<DTOOrder> GetOrders()
        {
            var db = new PapaBobsPizzaEntities();
            var orders = db.Orders.Where(p => p.OrderCompleted == false).ToList(); ;
            List<DTOOrder> DTOorders = convertToDTO(orders);
            return DTOorders;
        }
        private static List<DTOOrder> convertToDTO(List<Order> orders)
        {
            var DTOorders = new List<DTOOrder>();

            foreach (var order in orders)
            {
                var orderDTO = new DTOOrder();
                orderDTO.Id = order.Id;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.Zip = order.Zip;
                orderDTO.Phone = order.Phone;
                orderDTO.Size = order.Size;
                orderDTO.Crust = order.Crust;
                orderDTO.Sausage = order.Sausage;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Onions = order.Onions;
                orderDTO.GreenPeppers = order.GreenPeppers;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.TotalCost = order.TotalCost;
                DTOorders.Add(orderDTO);
            }
            return DTOorders;
        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PapaBobsPizzaEntities();
            var order = db.Orders.FirstOrDefault(p => p.Id == orderId);
            order.OrderCompleted = true;
            db.SaveChanges();
        }

        public static void SaveOrder(DTOOrder newOrder)
        {
            var db = new PapaBobsPizzaEntities();
            
                var orderDB = new Order();
                orderDB.Id = newOrder.Id;
                orderDB.Name = newOrder.Name;
                orderDB.Address = newOrder.Address;
                orderDB.Zip = newOrder.Zip;
                orderDB.Phone = newOrder.Phone;
                orderDB.Size = newOrder.Size;
                orderDB.Crust = newOrder.Crust;
                orderDB.Sausage = newOrder.Sausage;
                orderDB.Pepperoni = newOrder.Pepperoni;
                orderDB.Onions = newOrder.Onions;
                orderDB.GreenPeppers = newOrder.GreenPeppers;
                orderDB.PaymentType = newOrder.PaymentType;
                orderDB.TotalCost = newOrder.TotalCost;
                db.Orders.Add(orderDB);
            db.SaveChanges();
        }
    }
}
