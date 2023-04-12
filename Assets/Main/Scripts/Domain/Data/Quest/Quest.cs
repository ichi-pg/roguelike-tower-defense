using System.Collections.Generic;

namespace Roguelike.Domain.Data
{
    public class Quest
    {
        public Room Room;
        public List<Room> Rooms;
        public List<Card> Deck;
    }
}