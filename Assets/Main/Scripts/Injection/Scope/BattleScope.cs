using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Domain.Repository;
using Roguelike.Infrastructure.Repository;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class BattleScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IBattleRepository, BattleRepository>(Lifetime.Singleton);
            builder.Register<BattleUseCase>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<BattleView>().UnderTransform(transform);
            builder.RegisterEntryPoint<BattlePresenter>(Lifetime.Singleton);
        }
    }
}