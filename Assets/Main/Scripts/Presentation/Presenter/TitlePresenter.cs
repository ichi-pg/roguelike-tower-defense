using UniRx;
using VContainer;
using VContainer.Unity;
using Roguelike.Domain.Repository;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class TitlePresenter : IStartable
    {
        [Inject]
        private Router _router;
        [Inject]
        private ISaveDataRepository _saveDataRepositry;
        [Inject]
        private TitleView _titleView;

        [Inject]
        public TitlePresenter()
        {
        }

        void IStartable.Start()
        {
            _titleView.OnClickStartButton.Subscribe(async _ =>
            {
                if (_saveDataRepositry.SaveData.Quest == null)
                {
                    await _router.Switch(AssetAddress.HomeScope);
                }
                else
                {
                    await _router.Switch(AssetAddress.QuestScope);
                }

            }).AddTo(_titleView);
        }
    }
}