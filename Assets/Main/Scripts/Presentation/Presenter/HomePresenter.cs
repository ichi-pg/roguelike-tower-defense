using UniRx;
using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class HomePresenter : IStartable
    {
        [Inject]
        private Router _router;
        [Inject]
        private HomeView _homeView;

        [Inject]
        public HomePresenter()
        {
        }

        void IStartable.Start()
        {
            _homeView.OnClickStartButton.Subscribe(async _ =>
            {
                await _router.Switch(AssetAddress.QuestScope);

            }).AddTo(_homeView);
        }
    }
}