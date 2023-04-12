using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.Presentation.View
{
    public class FloorView : MonoBehaviour
    {
        [SerializeField]
        private LayoutGroup _roomLayout;

        public LayoutGroup RoomLayout => _roomLayout;
    }
}