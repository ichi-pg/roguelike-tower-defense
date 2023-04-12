using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class HomeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<HomeUseCase>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<HomeView>().UnderTransform(transform);
            builder.RegisterEntryPoint<HomePresenter>(Lifetime.Singleton);
        }
    }
}