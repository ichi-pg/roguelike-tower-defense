using VContainer;
using Roguelike.Domain.Repository;

namespace Roguelike.Application.UseCase
{
    public class GameUseCase
    {
        [Inject]
        private ISaveDataRepository _saveDataRepository;
        [Inject]
        private IMasterDataRepository _masterDataRepository;

        [Inject]
        public GameUseCase()
        {
        }

        public void Start()
        {
            _masterDataRepository.Load();
            _saveDataRepository.Load();
        }
    }
}