using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class FloorPresenter : IStartable, IDisposable
    {
        [Inject]
        private QuestUseCase _questUseCase;
        [Inject]
        private FloorView _FloorView;
        [Inject]
        private LifetimeScope _scope;

        private AsyncOperationHandle<GameObject> _roomHandle;

        [Inject]
        public FloorPresenter()
        {
        }

        async void IStartable.Start()
        {
            _roomHandle = await _scope.Instantiate(
                _FloorView.RoomLayout, _questUseCase.Quest.Rooms, AssetAddress.RoomScope
            );
        }

        void IDisposable.Dispose()
        {
            Addressables.Release(_roomHandle);
        }
    }
}