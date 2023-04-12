using System.Collections.Generic;

namespace Roguelike.Domain.Data
{
    public class Player
    {
        public int HP;
        public List<Card> Deck;
        public List<Card> Hand;
        public List<Card> Field;
    }
}