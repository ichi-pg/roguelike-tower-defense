using System;
using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class CardPresenter : IStartable, ITickable, IDisposable
    {
        [Inject]
        private Router _router;
        [Inject]
        private CardView _cardView;

        [Inject]
        public CardPresenter()
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