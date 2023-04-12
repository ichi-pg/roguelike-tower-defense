using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class FloorScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<FloorView>().UnderTransform(transform);
            builder.RegisterEntryPoint<FloorPresenter>(Lifetime.Singleton);
        }
    }
}