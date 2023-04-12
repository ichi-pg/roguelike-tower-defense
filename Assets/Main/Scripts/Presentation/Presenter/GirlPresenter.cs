using System;
using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class GirlPresenter : IStartable, ITickable, IDisposable
    {
        [Inject]
        private Router _router;
        [Inject]
        private GirlView _girlView;

        [Inject]
        public GirlPresenter()
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