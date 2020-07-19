using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    class Deck
    {
        //propeties
        public List<Card> deck;
        public Deck()
        {
            deck = new List<Card> //initilises the cards
            {
                new Card(1, "heart", false, Properties.Resources.hearts_A, true),
                new Card(2, "heart", false, Properties.Resources.hearts_2, true),
                new Card(3, "heart", false, Properties.Resources.hearts_3, true),
                new Card(4, "heart", false, Properties.Resources.hearts_4, true),
                new Card(5, "heart", false, Properties.Resources.hearts_5, true),
                new Card(6, "heart", false, Properties.Resources.hearts_6, true),
                new Card(7, "heart", false, Properties.Resources.hearts_7, true),
                new Card(8, "heart", false, Properties.Resources.hearts_8, true),
                new Card(9, "heart", false, Properties.Resources.hearts_9, true),
                new Card(10, "heart", false, Properties.Resources.hearts_10, true),
                new Card(11, "heart", false, Properties.Resources.hearts_J, true),
                new Card(12, "heart", false, Properties.Resources.hearts_Q, true),
                new Card(13, "heart", false, Properties.Resources.hearts_K, true),

                new Card(1, "diamond", false, Properties.Resources.diamonds_A, true),
                new Card(2, "diamond", false, Properties.Resources.diamonds_2, true),
                new Card(3, "diamond", false, Properties.Resources.diamonds_3, true),
                new Card(4, "diamond", false, Properties.Resources.diamonds_4, true),
                new Card(5, "diamond", false, Properties.Resources.diamonds_5, true),
                new Card(6, "diamond", false, Properties.Resources.diamonds_6, true),
                new Card(7, "diamond", false, Properties.Resources.diamonds_7, true),
                new Card(8, "diamond", false, Properties.Resources.diamonds_8, true),
                new Card(9, "diamond", false, Properties.Resources.diamonds_9, true),
                new Card(10, "diamond", false, Properties.Resources.diamonds_10, true),
                new Card(11, "diamond", false, Properties.Resources.diamonds_J, true),
                new Card(12, "diamond", false, Properties.Resources.diamonds_Q, true),
                new Card(13, "diamond", false, Properties.Resources.diamonds_K, true),

                new Card(1, "club", false, Properties.Resources.clubs_A, true),
                new Card(2, "club", false, Properties.Resources.clubs_2, true),
                new Card(3, "club", false, Properties.Resources.clubs_3, true),
                new Card(4, "club", false, Properties.Resources.clubs_4, true),
                new Card(5, "club", false, Properties.Resources.clubs_5, true),
                new Card(6, "club", false, Properties.Resources.clubs_6, true),
                new Card(7, "club", false, Properties.Resources.clubs_7, true),
                new Card(8, "club", false, Properties.Resources.clubs_8, true),
                new Card(9, "club", false, Properties.Resources.clubs_9, true),
                new Card(10, "club", false, Properties.Resources.clubs_10, true),
                new Card(11, "club", false, Properties.Resources.clubs_J, true),
                new Card(12, "club", false, Properties.Resources.clubs_Q, true),
                new Card(13, "club", false, Properties.Resources.clubs_K, true),

                new Card(1, "spade", false, Properties.Resources.spades_A, true),
                new Card(2, "spade", false, Properties.Resources.spades_2, true),
                new Card(3, "spade", false, Properties.Resources.spades_3, true),
                new Card(4, "spade", false, Properties.Resources.spades_4, true),
                new Card(5, "spade", false, Properties.Resources.spades_5, true),
                new Card(6, "spade", false, Properties.Resources.spades_6, true),
                new Card(7, "spade", false, Properties.Resources.spades_7, true),
                new Card(8, "spade", false, Properties.Resources.spades_8, true),
                new Card(9, "spade", false, Properties.Resources.spades_9, true),
                new Card(10, "spade", false, Properties.Resources.spades_10, true),
                new Card(11, "spade", false, Properties.Resources.spades_J, true),
                new Card(12, "spade", false, Properties.Resources.spades_Q, true),
                new Card(13, "spade", false, Properties.Resources.spades_K, true),

            };
            List<Card> tempList = new List<Card>();
            for(int i = 0; i <12; i++) //creates a list of 12 uniqe pairs 
            {
                Card card = getRandomCard(); //uses the method vv to 
                while (tempList.Contains(card))
                {
                    card = getRandomCard(); 
                }
                tempList.Add(card); //adds card twich for each parr
                tempList.Add(card);
            }
            deck = tempList;
            shuffle();
        }
        private Card getRandomCard() //gets a random card object 
        {
            Random rand = new Random();
            return deck[rand.Next(deck.Count())]; 
        }

        public void Add(Card card)
        {
            this.deck.Add(card); 
        }
        public void Remove(Card removeCard) //if you need to remove a card, u can 
        {
            foreach(Card card in deck)
            {
                if(card.getValue() == removeCard.getValue())
                {
                    this.deck.Remove(card); 
                }
            }
        }
        public void shuffle() //shuffles the cards
        {
            Random rand = new Random();

            //for each card in the deck, pick another random card and swap them
            for (int i = deck.Count - 1; i > 0; i--)
            {
                //select a random number 
                int j = rand.Next(i + 1); //generates a random number between 0 and i (deck.count)
                //swap the first card and the selected card 
                Card tempCard = deck[i];
                deck[i] = deck[j];
                deck[j] = tempCard;
            }
        }

        public List<Card> getDeck() //get deck vv 
        {
            return deck; //return the deck 
        }
    }
}
