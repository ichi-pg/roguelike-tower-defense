using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UniRx;
using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Domain.Repository;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class BattlePresenter : IStartable, IDisposable
    {
        [Inject]
        private Router _router;
        [Inject]
        private BattleUseCase _battleUseCase;
        [Inject]
        private IBattleRepository _bttleRepository;
        [Inject]
        private LifetimeScope _scope;
        [Inject]
        private BattleView _battleView;

        private AsyncOperationHandle<GameObject> _cardHandle;

        [Inject]
        public BattlePresenter()
        {
        }

        async void IStartable.Start()
        {
            _battleUseCase.Start();

            _battleUseCase.OnWin.Subscribe(async player =>
            {
                if (player == _bttleRepository.Battle.Player)
                {
                    await _router.Switch(AssetAddress.FloorScope);
                }
                else
                {
                    await _router.Switch(AssetAddress.ResultScope);
                }

            }).AddTo(_battleView);

            _cardHandle = await _scope.Instantiate(
                _battleView.CardLayouts,
                _bttleRepository.Battle.Players.Select(player => player.Field),
                AssetAddress.CardScope
            );
        }

        void IDisposable.Dispose()
        {
            Addressables.Release(_cardHandle);
        }
    }
}