using VContainer;
using Roguelike.Domain.Data;
using Roguelike.Domain.Model;
using Roguelike.Domain.Repository;

namespace Roguelike.Application.UseCase
{
    public class QuestUseCase
    {
        [Inject]
        private IQuestRepository _questRepository;
        [Inject]
        private ISaveDataRepository _saveDataRepository;

        public Quest Quest => _questRepository.Quest;

        [Inject]
        public QuestUseCase()
        {
        }

        public void Start()
        {
            QuestModel.Start(_questRepository.Quest);
            QuestModel.Step(_saveDataRepository.SaveData, _questRepository.Quest, null);
            _saveDataRepository.Save();
        }

        public void Restart()
        {
        }

        public void Finish()
        {
            QuestModel.Finish(_saveDataRepository.SaveData);
            _saveDataRepository.Save();
        }
    }
}