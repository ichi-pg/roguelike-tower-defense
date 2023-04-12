using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Domain.Repository;
using Roguelike.Infrastructure.Repository;
using Roguelike.Presentation.Presenter;

namespace Roguelike.Injection.Scope
{
    public class QuestScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IQuestRepository, QuestRepository>(Lifetime.Singleton);
            builder.Register<QuestUseCase>(Lifetime.Singleton);
            builder.RegisterEntryPoint<QuestPresenter>(Lifetime.Singleton);
        }
    }
}