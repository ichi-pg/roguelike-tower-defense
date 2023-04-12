using System.Collections.Generic;
using Roguelike.Domain.Data;
using Roguelike.Domain.Repository;

namespace Roguelike.Infrastructure.CloudSave
{
    public class SaveDataRepository : ISaveDataRepository
    {
        SaveData ISaveDataRepository.SaveData => _saveData;

        private SaveData _saveData;

        void ISaveDataRepository.Load()
        {
            _saveData = new SaveData()
            {
                User = new User()
                {
                    Cards = new List<Card>(),
                },
                Girl = new Girl()
                {
                },
            };
        }

        void ISaveDataRepository.Save()
        {
        }
    }
}