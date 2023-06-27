using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    public class Card
    {
        public Constans.Color Color { get; }
        public Constans.Value Value { get; set; }

        public Card(Constans.Value value, Constans.Color color)
        {
            Value = value;
            Color = color;
        }
    }
}
