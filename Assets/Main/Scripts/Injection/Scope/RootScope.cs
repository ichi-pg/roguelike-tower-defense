using VContainer;
using VContainer.Unity;
using Roguelike.Domain.Repository;
using Roguelike.Infrastructure.CloudSave;
using Roguelike.Infrastructure.MasterMemory;
using Roguelike.Presentation.Common;

namespace Roguelike.Injection.Scope
{
    public class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IMasterDataRepository, MasterDataRepository>(Lifetime.Singleton);
            builder.Register<ISaveDataRepository, SaveDataRepository>(Lifetime.Singleton);
            builder.Register<Router>(Lifetime.Singleton);
        }
    }
}