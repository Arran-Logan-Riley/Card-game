using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //use this for the image 

namespace Card_Game
{
    class Card
    { //properties 
        private int cardValue;
        private string suit;
        private bool flipStatus;
        private Image cardImage;
        private bool alive; 
        //constructors 
        public Card(int cardValue, string suit, bool flipStatus, Image cardImage, bool alive)
        {
            this.cardValue = cardValue;
            this.suit = suit;
            this.flipStatus = flipStatus;
            this.cardImage = cardImage;
            this.alive = alive; 
        }
        public bool Compare(Card card)
        {
            if (card == this /*&& this.suit == card.suit*/) //comparing the suit of the card
            {
                return true;
            }
            else return false;
        }
        //------CARD VALUE getters and setters------
        public void setValue(int cardValue)
        {
            this.cardValue = cardValue;
        }
        public int getValue()
        {
            return this.cardValue; 
        }
        //------CARD SUIT setters and getters------
        public void setSuit(string suit)
        {
            this.suit = suit; 
        }
        public string getSuit()
        {
            return this.suit; 
        }
        //------getters and setters for CARD IMAGE------
        public void setCardImage(Image cardImage)
        {
            this.cardImage = cardImage;
        }
        public Image getCardImage()
        {
            return this.cardImage; 
        }
        //------FLIP STATUS getters and setters------
        public void setCardFlipStatus(bool flipStatus)
        {
            this.flipStatus = flipStatus;
        }
        public bool getCardFlipStatus()
        {
            return this.flipStatus;
        }
        //------ALIVE getters and setters------
        public void setAlive(bool alive)
        {
            this.alive = alive;
        }
        public bool getAlive()
        {
            return this.alive;
        }


    }
}



