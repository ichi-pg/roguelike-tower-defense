namespace Roguelike.Editor.CodeGeneration
{
    public static class Templates
    {
        public const string AssetAddress =
@"namespace Roguelike.Presentation.Common
{{
    public static class AssetAddress
    {{{0}
    }}
}}";

        public const string DomainData =
@"namespace Roguelike.Domain.Data
{{
    public class {0}
    {{
    }}
}}";

        public const string DomainModel =
@"using Roguelike.Domain.Data;

namespace Roguelike.Domain.Model
{{
    public static class {0}Model
    {{
    }}
}}";

        public const string DomainRepository =
@"using Roguelike.Domain.Data;

namespace Roguelike.Domain.Repository
{{
    public interface I{0}Repository
    {{
    }}
}}";

        public const string InfrastructureRepository =
@"using Roguelike.Domain.Data;
using Roguelike.Domain.Repository;

namespace Roguelike.Infrastructure.Repository
{{
    public class {0}Repository : I{0}Repository
    {{
    }}
}}";

        public const string ApplicationUseCase =
@"using VContainer;
using Roguelike.Domain.Data;
using Roguelike.Domain.Model;
using Roguelike.Domain.Repository;

namespace Roguelike.Application.UseCase
{{
    public class {0}UseCase
    {{
        [Inject]
        private I{0}Repository _{1}Repository;

        [Inject]
        public {0}UseCase()
        {{
        }}
    }}
}}";

        public const string PresentationPresenter =
@"using System;
using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Presentation.Common;
using Roguelike.Presentation.View;

namespace Roguelike.Presentation.Presenter
{{
    public class {0}Presenter : IStartable, ITickable, IDisposable
    {{
        [Inject]
        private Router _router;
        [Inject]
        private {0}UseCase _{1}UseCase;
        [Inject]
        private {0}View _{1}View;

        [Inject]
        public {0}Presenter()
        {{
        }}

        void IStartable.Start()
        {{
        }}

        void ITickable.Tick()
        {{
        }}

        void IDisposable.Dispose()
        {{
        }}
    }}
}}";

        public const string PresentationView =
@"using UnityEngine;

namespace Roguelike.Presentation.View
{{
    public class {0}View : MonoBehaviour
    {{
    }}
}}";

        public const string InjectionScope =
@"using VContainer;
using VContainer.Unity;
using Roguelike.Application.UseCase;
using Roguelike.Domain.Repository;
using Roguelike.Infrastructure.Repository;
using Roguelike.Presentation.Presenter;
using Roguelike.Presentation.View;

namespace Roguelike.Injection.Scope
{{
    public class {0}Scope : LifetimeScope
    {{
        protected override void Configure(IContainerBuilder builder)
        {{
            builder.Register<I{0}Repository, {0}Repository>(Lifetime.Singleton);
            builder.Register<{0}UseCase>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<{0}View>().UnderTransform(transform);
            builder.RegisterEntryPoint<{0}Presenter>(Lifetime.Singleton);
        }}
    }}
}}";
    }
}