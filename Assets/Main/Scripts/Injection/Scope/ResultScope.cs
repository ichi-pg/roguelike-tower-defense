using VContainer;
using VContainer.Unity;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{
    public class ResultScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<ResultView>().UnderTransform(transform);
            builder.RegisterEntryPoint<ResultPresenter>(Lifetime.Singleton);
        }
    }
}