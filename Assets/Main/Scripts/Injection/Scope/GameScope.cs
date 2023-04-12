using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Presentation.Presenter;

namespace Roguelike.Injection.Scope
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameUseCase>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GamePresenter>(Lifetime.Singleton);
        }
    }
}