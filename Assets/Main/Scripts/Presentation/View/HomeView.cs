using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Roguelike.Presentation.View
{
    public class HomeView : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton;

        public IObservable<Unit> OnClickStartButton => _startButton.onClick.AsObservable();
    }
}