using UnityEngine;
using UnityEngine.UI;

namespace PuzzleBuilder
{
    public class PuzzleArea : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        public void Resize(Vector2 relativeSize, Vector2 maxPuzzleAreaSize)
        {
            Vector2 absoluteSize; //Size in pixels
            if(relativeSize.x < relativeSize .y)
            {
                absoluteSize = new Vector2(relativeSize.x / relativeSize.y * maxPuzzleAreaSize.y, maxPuzzleAreaSize.y); 
            }
            else
            {
                absoluteSize = new Vector2(maxPuzzleAreaSize.x, relativeSize.y / relativeSize.x * maxPuzzleAreaSize.x);
            }

            float offsetX = (maxPuzzleAreaSize.x - absoluteSize.x) / (2 * maxPuzzleAreaSize.x); //relative distance between MaxPuzzleArea border and vertical PuzzleArea border
            Vector2 anchorX = new Vector2(offsetX ,  (1 - offsetX));
            float offsetY = (maxPuzzleAreaSize.y - absoluteSize.y) / (2 * maxPuzzleAreaSize.y); //relative distance between MaxPuzzleArea border and horizontal PuzzleArea border
            Vector2 anchorY = new Vector2(offsetY , (1 - offsetY));

            _rectTransform.anchorMin = new Vector2(anchorX.x, anchorY.x);
            _rectTransform.anchorMax = new Vector2(anchorX.y, anchorY.y);
        }
    }
}

