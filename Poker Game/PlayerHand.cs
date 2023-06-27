using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    public class PlayerHand
    {
        
        
            public List<Card> PlayerCards { get; }
            public List<Card> TableCards { get; }


            public PlayerHand()
            {
                PlayerCards = new List<Card>();
                TableCards = new List<Card>();
            }
            /// <summary>
            /// Dodawanie karty do ręki gracza
            /// </summary>
            /// <param name="card"> Karta </param>
            public void AddPlayerCard(Card card)
            {
                PlayerCards.Add(card);
            }



            /// <summary>
            /// Dodawanie karty do kart na stole (wspolnych)
            /// </summary>
            /// <param name="card"> Karta </param>
            public void AddTableCard(Card card)
            {
                TableCards.Add(card);
            }


        


    }
}
