using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class TitleScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<TitleView>().UnderTransform(transform);
            builder.RegisterEntryPoint<TitlePresenter>(Lifetime.Singleton);
        }
    }
}