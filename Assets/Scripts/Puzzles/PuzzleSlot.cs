using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzles
{
    public class PuzzleSlot : MonoBehaviour, IDropHandler
    {
        private Image _image;

        private void Start() => _image = GetComponent<Image>();

        public void OnDrop(PointerEventData eventData)
        {
            ChangeRayTarget(false);
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
        }

        public void ChangeRayTarget(bool isActive) => _image.raycastTarget = isActive;
    }
}