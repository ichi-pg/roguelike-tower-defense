using UniRx;
using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class ResultPresenter : IStartable
    {
        [Inject]
        private Router _router;
        [Inject]
        private ResultView _resultView;

        [Inject]
        public ResultPresenter()
        {
        }

        void IStartable.Start()
        {
            _resultView.OnClickFinishButton.Subscribe(async _ =>
            {
                _router.Pop();
                await _router.Switch(AssetAddress.HomeScope);

            }).AddTo(_resultView);
        }
    }
}