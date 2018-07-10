using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsPizza.DTO;
using PapaBobsPizza.Persistence;

namespace PapaBobsPizza.Domain
{
    public class OrdersManager
    {
        public static void SaveOrder(DTO.DTOOrder newOrder)
        {
            OrderRepository.SaveOrder(newOrder);
        }
        public static List<DTOOrder> GetOrders()
        {
            var orders = OrderRepository.GetOrders();
            return orders;
        }

        public static Decimal CalculateTotalCost(DTOOrder order)
        {
            var db = new PapaBobsPizzaEntities();
            var pizzaprices = db.PizzaPrices.FirstOrDefault();
            var crust = determineCrust(order, pizzaprices);
            var size = determineSize(order, pizzaprices);
            var sausage = determineSausage(order, pizzaprices);
            var pepperoni = determinePepperoni(order, pizzaprices);
            var onions = determineOnions(order, pizzaprices);
            var greenPeppers = determineGreenPeppers(order, pizzaprices);

            var TotalCost = crust + size + sausage + pepperoni + onions + greenPeppers;

            return TotalCost;
            
        }

        public static void CompleteOrder(Guid orderId)
        {
            OrderRepository.CompleteOrder(orderId);
        }

        private static Decimal determineGreenPeppers(DTOOrder order, PizzaPrice pizzaprices)
        {
            if (order.GreenPeppers) return pizzaprices.GreenPeppersPrice;
            else return 0;
        }

        private static Decimal determineOnions(DTOOrder order, PizzaPrice pizzaprices)
        {
            if (order.Onions) return pizzaprices.OnionsPrice;
            else return 0;
        }

        private static Decimal determinePepperoni(DTOOrder order, PizzaPrice pizzaprices)
        {
            if (order.Pepperoni) return pizzaprices.PepperoniPrice;
            else return 0;
        }
        
        private static Decimal determineSausage(DTOOrder order, PizzaPrice pizzaprices)
        {
            if (order.Sausage) return pizzaprices.SausagePrice;
            else return 0;
        }

        private static Decimal determineSize(DTOOrder order, PizzaPrice pizzaprices)
        {
            if (order.Size == DTO.Enums.SizeType.Small) return pizzaprices.SmallPizzaPrice;
            else if (order.Size == DTO.Enums.SizeType.Medium) return pizzaprices.MediumPizzaPrice;
            else if (order.Size == DTO.Enums.SizeType.Large) return pizzaprices.LargePizzaPrice;
            else return 0;
        }

        private static Decimal determineCrust(DTOOrder order, PizzaPrice pizzaprices)
        {
            var price = 0M;

            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Regular:
                    price = pizzaprices.RegularPizzaPrice;
                    break;
                case DTO.Enums.CrustType.Thin:
                    price = pizzaprices.ThinPizzaPrice;
                    break;
                case DTO.Enums.CrustType.Thick:
                    price = pizzaprices.ThickPizzaPrice;
                    break;
            }
            return price;
        }
    }
}
