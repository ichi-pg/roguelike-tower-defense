using System.Collections.Generic;
using Roguelike.Domain.Data;
using Roguelike.Domain.Repository;

namespace Roguelike.Infrastructure.MasterMemory
{
    public class MasterDataRepository : IMasterDataRepository
    {
        MasterData IMasterDataRepository.MasterData => _masterData;

        private MasterData _masterData;

        void IMasterDataRepository.Load()
        {
            _masterData = new MasterData()
            {
                Girls = new List<Girl>(),
                Cards = new List<Card>(),
                Perks = new List<Perk>(),
                Events = new List<Event>(),
            };
        }
    }
}