using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace CS_ASP_051_MegaChallangeWarGame_2nd_Try.Classes
{
    public class Battle
    {
        private List<Card> _bounty { get; set; }
        private StringBuilder _sb;
        
        public Battle()
        {
            _bounty = new List<Card>();
            _sb = new StringBuilder();
        }

        public string PerformBattle(Player player1, Player player2)
        {
            Card player1Card = GetCard(player1);
            Card player2Card = GetCard(player2);

            performEvaluation(player1, player2, player1Card, player2Card);
            return _sb.ToString();
        }

        private Card GetCard(Player player)
        {
            Card card = player.Cards.ElementAt(0);
            _bounty.Add(card);
            player.Cards.Remove(card);
            return card;
        }

        private void performEvaluation(Player player1, Player player2, Card Player1Card, Card Player2Card)
        {
            displayBattleCards(Player1Card, Player2Card);
            if (Player1Card.CardValue() == Player2Card.CardValue())
                war(player1, player2);
            if (Player1Card.CardValue() > Player2Card.CardValue())
                awardWinner(player1);
            else
                awardWinner(player2);            
        }

        private void awardWinner(Player player)
        {
            if (_bounty.Count == 0) return;
            displayBountyCards();
            _sb.Append("<br/><span style='font-weight: bolder'>Winner: ");
            _sb.Append(player.Name);
            _sb.Append("</span ><br/><br/>");
            player.Cards.AddRange(_bounty);
            _bounty.Clear();
        }
        private void war(Player player1, Player player2)
        {
            GetCard(player1);
            Card warCard1 = GetCard(player1);
            GetCard(player1);

            GetCard(player2);
            Card warCard2 = GetCard(player2);
            GetCard(player2);
            _sb.Append("<br/><h3>*********************WAR!*********************</h3>");
            performEvaluation(player1, player2, warCard1, warCard2);
        }
        private void displayBattleCards(Card card1, Card card2)
        {
            _sb.Append("<br/>Battle cards: ");
            _sb.Append(card1.Kind);
            _sb.Append(" of ");
            _sb.Append(card1.Suit);
            _sb.Append(" versus ");
            _sb.Append(card2.Kind);
            _sb.Append(" of ");
            _sb.Append(card2.Suit);
        }

        private void displayBountyCards()
        {
            _sb.Append("<br/><br/><span style='font-weight: bolder'>Bounty ...</span>");

         foreach (var card in _bounty)
            {
                _sb.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;");
                _sb.Append(card.Kind);
                _sb.Append(" of ");
                _sb.Append(card.Suit);                
            }

           
        }
    }
}