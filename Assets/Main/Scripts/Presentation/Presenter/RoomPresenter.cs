using UniRx;
using VContainer;
using VContainer.Unity;
using Roguelike.Domain.Data;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{
    public class RoomPresenter : IStartable
    {
        [Inject]
        private Router _router;
        [Inject]
        private RoomView _roomView;
        [Inject]
        private Room _room;

        [Inject]
        public RoomPresenter()
        {
        }

        void IStartable.Start()
        {
            _roomView.OnClickButton.Subscribe(async _ =>
            {
                await _router.Switch(AssetAddress.BattleScope);

            }).AddTo(_roomView);
        }
    }
}