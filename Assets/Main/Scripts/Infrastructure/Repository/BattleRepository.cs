using Roguelike.Domain.Data;
using Roguelike.Domain.Repository;

namespace Roguelike.Infrastructure.Repository
{
    public class BattleRepository : IBattleRepository
    {
        Battle IBattleRepository.Battle => _battle;

        private Battle _battle = new Battle();
    }
}