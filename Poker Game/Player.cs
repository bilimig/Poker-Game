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
            bool isstrited = false;
            bool iscolored = false;
            bool ispokered = false;

            var duplicates = handTableCards.GroupBy(i => i.Value)
                                                .Where(g => g.Count() >= 2) // rozwazyc == 2 
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
                    if (isstrited)
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

            if (count >= 5)
            {
                var colored = handTableCards.GroupBy(i => i.Color)
                                                .Where(g => g.Count() >= 5)
                                                    .Select(g => g.Key);
                if (colored.Any())
                {
                    iscolored = true;
                    currentPatern = Constans.Patterns.Flush;
                    // w przypadku remisu podzial na pol
                }
            }


            if (count >= 5)
            {
                if (triples.Any() && (duplicates.Count() == 2))
                {
                    currentPatern = Constans.Patterns.FullHouse;
                }
            }


            var quarters = handTableCards.GroupBy(i => i.Value)
                                          .Where(g => g.Count() >= 4)
                                              .Select(g => g.Key);
            if (count >= 4)
            {

                if (quarters.Any())
                {
                    currentPatern = Constans.Patterns.FourOfKind;
                    highestCard.Value = quarters.First();
                }

            }
            if (isstrited && iscolored)
            {
                ispokered = false;
                for (var j = 0; j <= count - 5; j++)
                {
                    if (ispokered)
                    {
                        break;
                    }

                    for (var i = 0; i < 4; i++)
                    {

                        if (handTableCards[count - i - j - 1].Value == handTableCards[count - i - j].Value - 1 && handTableCards[count - i - j - 1].Color == handTableCards[count - i - j].Color)
                        {
                            ispokered = true;
                        }
                        else
                        {
                            ispokered = false;
                            break;
                        }
                        if (ispokered && i == 0)
                        {
                            currentPatern = Constans.Patterns.StraightFlush;
                            highestCard.Value = handTableCards[count - j].Value;
                        }

                    }
                }
            }
            if (ispokered)
            {

                if (highestCard.Value == Constans.Value.Ace)
                {
                    currentPatern = Constans.Patterns.RoyalFlush;
                }

            }

            return currentPatern;
        }

    }
}


