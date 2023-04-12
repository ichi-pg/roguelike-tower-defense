using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class CardScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<CardView>().UnderTransform(transform);
            builder.RegisterEntryPoint<CardPresenter>(Lifetime.Singleton);
        }
    }
}