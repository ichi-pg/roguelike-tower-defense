using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Roguelike.Presentation.View
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField]
        private Button _finishButton;

        public IObservable<Unit> OnClickFinishButton => _finishButton.onClick.AsObservable();
    }
}