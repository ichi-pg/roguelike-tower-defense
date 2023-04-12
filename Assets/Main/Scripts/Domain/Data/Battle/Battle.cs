using System.Collections.Generic;

namespace Roguelike.Domain.Data
{
    public class Battle
    {
        public Player Player;
        public Player Enemy;
        public List<Player> Players;
    }
}