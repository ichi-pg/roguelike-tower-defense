using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.Presentation.View
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField]
        private LayoutGroup[] _cardLayouts;

        public LayoutGroup[] CardLayouts => _cardLayouts;
    }
}