using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizza.DTO
{
    public class DTOPizzaPrices
    {
        public int Id { get; set; }
        public decimal SmallPizzaPrice { get; set; }
        public decimal MediumPizzaPrice { get; set; }
        public decimal LargePizzaPrice { get; set; }
        public decimal RegularPizzaPrice { get; set; }
        public decimal ThinPizzaPrice { get; set; }
        public decimal ThickPizzaPrice { get; set; }
        public decimal SausagePrice { get; set; }
        public decimal PepperoniPrice { get; set; }
        public decimal OnionsPrice { get; set; }
        public decimal GreenPeppersPrice { get; set; }
    }
}
