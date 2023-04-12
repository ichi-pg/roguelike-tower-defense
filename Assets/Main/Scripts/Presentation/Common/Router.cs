using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Roguelike.Presentation.Common
{
    public class Router
    {
        private Stack<Tuple<AsyncOperationHandle, GameObject>> _stack = new Stack<Tuple<AsyncOperationHandle, GameObject>>();

        public async UniTask Switch(string prefabName)
        {
            Pop();

            await Push(prefabName);
        }

        public async UniTask Push(string prefabName)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(prefabName);

            await handle.Task;

            var obj = Instantiate(handle.Result);

            _stack.Push(new Tuple<AsyncOperationHandle, GameObject>(handle, obj));
        }

        private GameObject Instantiate(GameObject prefab)
        {
            Tuple<AsyncOperationHandle, GameObject> peek;
            if (_stack.TryPeek(out peek))
            {
                LifetimeScope parent;
                if (peek.Item2.TryGetComponent<LifetimeScope>(out parent))
                {
                    using (LifetimeScope.EnqueueParent(parent))
                    {
                        return GameObject.Instantiate(prefab);
                    }
                }
            }
            return GameObject.Instantiate(prefab);
        }

        public void Pop()
        {
            var tuple = _stack.Pop();
            GameObject.Destroy(tuple.Item2);
            Addressables.Release(tuple.Item1);
        }
    }
}