using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzles
{
    public class LayoutPuzzleBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private GameObject _slotPrefab;
        public void PrepareSlots(int slotsToPrepare, Vector2 size)
        {
            for (int i = 0; i < slotsToPrepare; i++)
            {
                GameObject newSlot = Instantiate(_slotPrefab, _rectTransform);
                RectTransform slotRectTransform = newSlot.GetComponent<RectTransform>();
                slotRectTransform.sizeDelta = size;
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }
        public RectTransform GetNewSlotTransform()
        {
            foreach (Transform child in transform)
            {
                if (child.childCount <= 0)
                    return child.GetComponent<RectTransform>();
            }

            return null;
        }
    }
}

