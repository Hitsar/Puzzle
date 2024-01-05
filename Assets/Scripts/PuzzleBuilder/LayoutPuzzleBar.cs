using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzles
{
    public class LayoutPuzzleBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private GameObject _slotPrefab;
        private List<RectTransform> _slots = new List<RectTransform>();
        public void PrepareSlots(int slotsToPrepare, Vector2 size)
        {
            for (int i = 0; i < slotsToPrepare; i++)
            {
                GameObject newSlot = Instantiate(_slotPrefab, _rectTransform);
                RectTransform slotRectTransform = newSlot.GetComponent<RectTransform>();
                slotRectTransform.sizeDelta = size;
                _slots.Add(slotRectTransform);
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }
        public RectTransform GetNewSlotTransform()
        {
            foreach (var slot in _slots)
            {
                if (slot.childCount <= 0)
                    return slot.GetComponent<RectTransform>();
            }

            return null;
        }
    }
}

