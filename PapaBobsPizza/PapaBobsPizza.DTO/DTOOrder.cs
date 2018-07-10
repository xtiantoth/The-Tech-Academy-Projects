using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsPizza.DTO
{
    public class DTOOrder
    {
        public System.Guid Id { get; set; }
        public Enums.SizeType Size { get; set; }
        public Enums.CrustType Crust { get; set; }
        public bool Sausage { get; set; }
        public bool Pepperoni { get; set; }
        public bool Onions { get; set; }
        public bool GreenPeppers { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public Enums.PaymentType PaymentType { get; set; }
        public decimal TotalCost { get; set; }
        public bool OrderCompleted { get; set; }
    }
}
