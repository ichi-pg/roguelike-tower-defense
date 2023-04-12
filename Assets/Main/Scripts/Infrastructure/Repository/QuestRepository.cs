using Roguelike.Domain.Data;
using Roguelike.Domain.Repository;

namespace Roguelike.Infrastructure.Repository
{
    public class QuestRepository : IQuestRepository
    {
        Quest IQuestRepository.Quest => _quest;

        private Quest _quest = new Quest();
    }
}