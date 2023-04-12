using System;
using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class PlayerPresenter : IStartable, ITickable, IDisposable
    {
        [Inject]
        private Router _router;
        [Inject]
        private PlayerView _playerView;

        [Inject]
        public PlayerPresenter()
        {
        }

        void IStartable.Start()
        {
        }

        void ITickable.Tick()
        {
        }

        void IDisposable.Dispose()
        {
        }
    }
}