using System;
using UniRx;
using VContainer;
using Roguelike.Domain.Data;
using Roguelike.Domain.Model;
using Roguelike.Domain.Repository;

namespace Roguelike.Application.UseCase
{
    public class BattleUseCase
    {
        [Inject]
        private IBattleRepository _battleRepository;
        [Inject]
        private IQuestRepository _questRepository;
        [Inject]
        private ISaveDataRepository _saveDataRepository;

        private Subject<Player> _onWin = new Subject<Player>();
        private Subject<Card> _onDestroy = new Subject<Card>();
        private Subject<(Card, int)> _onDamage = new Subject<(Card, int)>();

        public IObservable<Player> OnWin => _onWin;
        public IObservable<Card> OnDestroy => _onDestroy;
        public IObservable<(Card, int)> OnDamage => _onDamage;

        [Inject]
        public BattleUseCase()
        {
        }

        public void Start()
        {
            BattleModel.Start(_questRepository.Quest, _battleRepository.Battle);
        }

        public void Step()
        {
            BattleModel.Step(_battleRepository.Battle, _onWin, _onDestroy, _onDamage);
        }

        public void Finish(Room room, Card card)
        {
            QuestModel.EarnCard(_questRepository.Quest, card);
            QuestModel.Step(_saveDataRepository.SaveData, _questRepository.Quest, room);
            _saveDataRepository.Save();
        }
    }
}