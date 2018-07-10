using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsPizza.DTO;
using PapaBobsPizza.Persistence;

namespace PapaBobsPizza.Domain
{
    public static class PizzaPricesManager
    {
        public static DTO.DTOPizzaPrices getPizzaPrices()
        {
            var db = new PapaBobsPizzaEntities();
            var DTOPizzaPrices = new DTO.DTOPizzaPrices();
            var PizzaPrices = db.PizzaPrices.FirstOrDefault();
            DTOPizzaPrices.Id = PizzaPrices.Id;
            DTOPizzaPrices.LargePizzaPrice = PizzaPrices.LargePizzaPrice;
            DTOPizzaPrices.MediumPizzaPrice = PizzaPrices.MediumPizzaPrice;
            DTOPizzaPrices.OnionsPrice = PizzaPrices.OnionsPrice;
            DTOPizzaPrices.PepperoniPrice = PizzaPrices.PepperoniPrice;
            DTOPizzaPrices.RegularPizzaPrice = PizzaPrices.RegularPizzaPrice;
            DTOPizzaPrices.SausagePrice = PizzaPrices.SausagePrice;
            DTOPizzaPrices.SmallPizzaPrice = PizzaPrices.SmallPizzaPrice;
            DTOPizzaPrices.ThickPizzaPrice = PizzaPrices.ThickPizzaPrice;
            DTOPizzaPrices.ThinPizzaPrice = PizzaPrices.ThinPizzaPrice;
            DTOPizzaPrices.GreenPeppersPrice = PizzaPrices.GreenPeppersPrice;

            return DTOPizzaPrices;
        }

        public static decimal calculateTotalCost(DTO.DTOOrder order)
        {
            var db = new PapaBobsPizzaEntities();
            var pizzaPrices = db.PizzaPrices.FirstOrDefault();
            var crustPrice = getCrustPrice(order);
            var sizePrice = getSizePrice(order);
            var sausagePrice = (order.Sausage) ? pizzaPrices.SausagePrice : 0;
            var pepperoniPrice = (order.Pepperoni) ? pizzaPrices.PepperoniPrice : 0;
            var onionsPrice = (order.Onions) ? pizzaPrices.OnionsPrice : 0;
            var greenPeppersPrice = (order.GreenPeppers) ? pizzaPrices.GreenPeppersPrice : 0;
            decimal totalCost =
                 crustPrice
                + sizePrice
                + sausagePrice
                + pepperoniPrice
                + onionsPrice
                + greenPeppersPrice;

            return totalCost;
        }

        private static decimal getSizePrice(DTOOrder order)
        {
            var pizzaPrices = getPizzaPrices();
            var sizePrice = 0M;

            switch (order.Size)
            {
                case DTO.Enums.SizeType.Small:
                    sizePrice = pizzaPrices.SmallPizzaPrice;
                    break;
                case DTO.Enums.SizeType.Medium:
                    sizePrice = pizzaPrices.MediumPizzaPrice;
                    break;
                case DTO.Enums.SizeType.Large:
                    sizePrice = pizzaPrices.LargePizzaPrice;
                    break;
                default:
                    break;
            }
            return sizePrice;
        }

        private static decimal getCrustPrice(DTOOrder order)
        {
            var pizzaPrices = getPizzaPrices();
            var crustPrice = 0M;

            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Regular:
                    crustPrice = pizzaPrices.RegularPizzaPrice;
                    break;
                case DTO.Enums.CrustType.Thin:
                    crustPrice = pizzaPrices.ThinPizzaPrice;
                    break;
                case DTO.Enums.CrustType.Thick:
                    crustPrice = pizzaPrices.ThickPizzaPrice;
                    break;
            }
            return crustPrice;
        }
    }
}
