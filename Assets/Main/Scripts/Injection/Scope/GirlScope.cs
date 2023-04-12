using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class GirlScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GirlView>().UnderTransform(transform);
            builder.RegisterEntryPoint<GirlPresenter>(Lifetime.Singleton);
        }
    }
}