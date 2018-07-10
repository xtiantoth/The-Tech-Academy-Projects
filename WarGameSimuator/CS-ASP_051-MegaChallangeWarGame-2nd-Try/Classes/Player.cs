using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_051_MegaChallangeWarGame_2nd_Try.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        public Player()
        {
            Cards = new List<Card>();
        }
    }

    
}