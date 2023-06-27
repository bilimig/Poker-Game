using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    public class Player
    {

        public string Name { get; }
        public List<Card> Hand { get; }
        public int Chips { get; private set; }
        public int CurrentBet { get; private set; }
        Card highestCard;

        public Player(string name, int startingChips)
        {
            Name = name;
            Hand = new List<Card>();
            Chips = startingChips;
            CurrentBet = 0;
        }

        public void DealCards(Card card)
        {
            Hand.Add(card);
        }
        public void PlaceBet(int amount)
        {
            if (amount > Chips)
            {
                amount = Chips;
            }
            Chips -= amount;
            CurrentBet += amount;
        }

        public void Fold()
        {
            Hand.Clear();
            CurrentBet = 0;
        }
        public void ClearHand()
        {
            Hand.Clear();
        }
        public Constans.Patterns CheckPattern(List<Card> TableCards)
        {
            List<Card> handTableCards = new List<Card>(TableCards);
            handTableCards.AddRange(Hand);
            handTableCards = handTableCards.OrderBy(i => i.Value).ToList();
            Constans.Patterns currentPatern = Constans.Patterns.HighCard;
            int count = handTableCards.Count();
            bool isstrited;

            var duplicates = handTableCards.GroupBy(i => i.Value)
                                                .Where(g => g.Count() >= 2)
                                                    .Select(g => g.Key);
            if (duplicates.Any())
            {
                if (duplicates.Count() == 1)
                {
                    currentPatern = Constans.Patterns.OnePair;
                    Constans.Value value = duplicates.FirstOrDefault();
                    highestCard.Value = value;
                }

                if (duplicates.Count() == 2)
                {
                    currentPatern = Constans.Patterns.TwoPairs;
                    Constans.Value value = duplicates.Max();
                    highestCard.Value = value;
                }


            }
            var triples = handTableCards.GroupBy(i => i.Value)
                                                .Where(g => g.Count() >= 3)
                                                    .Select(g => g.Key);
            if (triples.Any())
            {
                currentPatern = Constans.Patterns.ThreeOfKind;
                highestCard.Value = triples.First();
            }
            if (count >= 5)
            {
                isstrited = false;
                for (var j = 0; j <= count - 5; j++)
                {
                    if(isstrited)
                    {
                        break;
                    }

                    for (var i = 0; i < 4; i++)
                    {

                        if (handTableCards[count - i - j - 1].Value == handTableCards[count - i - j].Value - 1)
                        {
                            isstrited = true;
                        }
                        else
                        {
                            isstrited = false;
                            break;
                        }
                        if (isstrited && i == 0)
                        {
                            currentPatern = Constans.Patterns.Straight;
                            highestCard.Value = handTableCards[count - j].Value;
                        }

                    }
                }

            }



            return currentPatern;
        }

    }
}
