using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Roguelike.Presentation.View
{
    public class RoomView : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        public IObservable<Unit> OnClickButton => _button.onClick.AsObservable();
    }
}