using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class PlayerScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<PlayerView>().UnderTransform(transform);
            builder.RegisterEntryPoint<PlayerPresenter>(Lifetime.Singleton);
        }
    }
}