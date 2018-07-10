﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_051_MegaChallangeWarGame_2nd_Try.Classes
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        
        public Game(string Player1Name, string Player2Name)
        { 
            _player1 = new Player() { Name = Player1Name };
            _player2 = new Player() { Name = Player2Name };
        }

        public string Play()
        {
            Deck deck = new Deck();
            string result = "<br/><h3>Dealing cards ...</h3>";
            result += deck.Deal(_player1, _player2);
            result += "<br/><h3>Begin battle...</h3>";
            int round = 0;
            while (_player1.Cards.Count != 0 && _player2.Cards.Count != 0)
            {   
                Battle battle = new Battle();
                result += battle.PerformBattle(_player1, _player2);
                round++;
                if (round > 20) break;
            }

            result += determineWinner();
            return result;
        }

        private string determineWinner()
        {
            string result = "";

            if (_player1.Cards.Count > _player2.Cards.Count)
                result += "<br/><span style='color: red; font-weight: bolder;'>Player 1 wins</span>";
            else result += "<br/><span style='color: blue; font-weight: bolder;'>Player 2 wins</span>";

            result += "<br/><span style='color: red; font-weight: bolder;'>Player1: "
                + _player1.Cards.Count + "</span>" + "<br/><span style='color: blue; font-weight: bolder;'>Player2: " + _player2.Cards.Count + "</span>";

            return result;
        }

       
    }
}