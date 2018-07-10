using CS_ASP_051_MegaChallangeWarGame_2nd_Try.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CS_ASP_051_MegaChallangeWarGame_2nd_Try
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            Game game = new Game("Player1", "Player2");
            resultLabel.Text = game.Play();
        }
    }
}