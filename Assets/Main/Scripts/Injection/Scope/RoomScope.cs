using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class RoomScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<RoomView>().UnderTransform(transform);
            builder.RegisterEntryPoint<RoomPresenter>(Lifetime.Singleton);
        }
    }
}