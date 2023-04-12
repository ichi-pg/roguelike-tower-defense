using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Domain.Repository;
using Roguelike.Presentation.Common;

namespace Roguelike.Presentation.Presenter
{
    public class QuestPresenter : IStartable
    {
        [Inject]
        private Router _router;
        [Inject]
        private ISaveDataRepository _saveDataRepositry;
        [Inject]
        private QuestUseCase _questUseCase;

        [Inject]
        public QuestPresenter()
        {
        }

        async void IStartable.Start()
        {
            if (_saveDataRepositry.SaveData.Quest == null)
            {
                _questUseCase.Restart();
            }
            else
            {
                _questUseCase.Start();
            }

            await _router.Push(AssetAddress.FloorScope);
        }
    }
}