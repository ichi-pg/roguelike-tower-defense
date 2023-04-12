using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace Roguelike.Presentation.Common
{
    public static class LifetimeScopeExtensions
    {
        public static async UniTask<AsyncOperationHandle<GameObject>> Instantiate<T>(this LifetimeScope parentScope, IEnumerable<Component> parentComponents, IEnumerable<IEnumerable<T>> entitiesList, string prefabName)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(prefabName);

            await handle.Task;

            Instantiate(parentScope, parentComponents, entitiesList, handle.Result);

            return handle;
        }

        public static void Instantiate<T>(this LifetimeScope parentScope, IEnumerable<Component> parentComponents, IEnumerable<IEnumerable<T>> entitiesList, GameObject prefab)
        {
            var stack = new Stack<Component>(parentComponents);

            foreach (var entities in entitiesList)
            {
                Instantiate(parentScope, stack.Pop().transform, entities, prefab);
            }
        }

        public static async UniTask<AsyncOperationHandle<GameObject>> Instantiate<T>(this LifetimeScope parentScope, Component parentComponent, IEnumerable<T> entities, string prefabName)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(prefabName);

            await handle.Task;

            Instantiate(parentScope, parentComponent, entities, handle.Result);

            return handle;
        }

        public static void Instantiate<T>(this LifetimeScope parentScope, Component parentComponent, IEnumerable<T> entities, GameObject prefab)
        {
            using (LifetimeScope.EnqueueParent(parentScope))
            {
                foreach (var entity in entities)
                {
                    Instantiate(parentComponent, entity, prefab);
                }
            }
        }

        public static void Instantiate<T>(this LifetimeScope parentScope, Component parentComponent, T entity, GameObject prefab)
        {
            using (LifetimeScope.EnqueueParent(parentScope))
            {
                Instantiate(parentComponent, entity, prefab);
            }
        }

        private static void Instantiate<T>(Component parentComponent, T entity, GameObject prefab)
        {
            using (LifetimeScope.Enqueue(builder =>
            {
                builder.RegisterInstance<T>(entity);
            }))
            {
                GameObject.Instantiate(prefab, parentComponent.transform);
            }
        }
    }
}