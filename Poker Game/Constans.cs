using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    public static class Constans
    {
        public enum Color
        {
            Spades,
            Hearts,
            Diamonds,
            Clubs
        }

        public enum Value
        {
            Two ,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace,
        }

        public enum Patterns
        {
            HighCard,
            OnePair,
            TwoPairs,
            ThreeOfKind,
            Straight,
            Flush,
            FullHouse,
            FourOfKind,
            StraightFlush,
            RoyalFlush,

        }
    }
}
