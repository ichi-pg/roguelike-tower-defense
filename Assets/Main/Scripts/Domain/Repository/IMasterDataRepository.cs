using Roguelike.Domain.Data;

namespace Roguelike.Domain.Repository
{
    public interface IMasterDataRepository
    {
        MasterData MasterData { get; }
        void Load();
    }
}