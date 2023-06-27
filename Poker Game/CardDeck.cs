using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    public class CardDeck
    {

        private List<Card> cards;

        public CardDeck()
        {
            cards = GenerateDeck();
        }

        /// <summary>
        /// Tworzenie Decku
        /// </summary>
        private List<Card> GenerateDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (Constans.Color color in Enum.GetValues(typeof(Constans.Color)))
            {
                foreach (Constans.Value value in Enum.GetValues(typeof(Constans.Value)))
                {
                    Card card = new Card(value, color);
                    deck.Add(card);
                }
            }

            return deck;
        }
        /// <summary>
        /// Tasowanie 
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        /// <summary>
        /// Pobieranie karty z góry decku
        /// </summary>
        /// <exception cref="InvalidOperationException"> Deck jest pusty</exception>
        /// <returns>Błąd Pusty Deck</returns>
        public Card DealCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty. No more cards to deal.");
            }

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

    }
}
