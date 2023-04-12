using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Presentation.Common;

namespace Roguelike.Presentation.Presenter
{
    public class GamePresenter : IStartable
    {
        [Inject]
        private Router _router;
        [Inject]
        private GameUseCase _gameUseCase;

        [Inject]
        public GamePresenter()
        {
        }

        async void IStartable.Start()
        {
            _gameUseCase.Start();

            await _router.Push(AssetAddress.TitleScope);
        }
    }
}