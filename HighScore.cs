using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    class HighScore
    {//properties 
        private int score;
        private string playerName; //This is uh, managing these two variables in a list 

        public HighScore(int score, string playerName) //constructor 
        {
             
            this.Score = score;
            this.PlayerName = playerName;
        }

        public int Score { get => score; set => score = value; }//getters and setters for the score
        public string PlayerName { get => playerName; set => playerName = value; }//getters and setters for the players name 
    }
}
