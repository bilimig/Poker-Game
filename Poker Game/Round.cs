using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    public class Round
    {
        private CardDeck deck;
        private List<Player> players;
        public List<Card> TableCards { get; private set; }
        public Round(List<Player> players)
        {
            this.players = players;
            deck = new CardDeck();
            TableCards = new List<Card>();
        }

        public void Start()
        {
            foreach (Player player in players)
            {
                player.ClearHand();
                player.DealCards(deck.DealCard());
                player.DealCards(deck.DealCard());
            }
        }
        public void DealTableCard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Card card = deck.DealCard();
                TableCards.Add(card);
            }
        }

      
    }
}
