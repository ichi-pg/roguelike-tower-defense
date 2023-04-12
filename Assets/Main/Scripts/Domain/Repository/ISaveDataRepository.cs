using Roguelike.Domain.Data;

namespace Roguelike.Domain.Repository
{
    public interface ISaveDataRepository
    {
        SaveData SaveData { get; }
        void Load();
        void Save();
    }
}