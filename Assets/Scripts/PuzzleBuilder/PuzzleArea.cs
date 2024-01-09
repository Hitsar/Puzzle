using UnityEngine;

namespace PuzzleBuilder
{
    public class PuzzleArea : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        public Vector2 Resize(Vector2 relativeSize, Vector2 maxPuzzleAreaSize)
        {
            Vector2 absoluteSize; //Size in pixels
            if(relativeSize.x < relativeSize .y)
                absoluteSize = new Vector2(relativeSize.x / relativeSize.y * maxPuzzleAreaSize.y, maxPuzzleAreaSize.y); 
            else
                absoluteSize = new Vector2(maxPuzzleAreaSize.x, relativeSize.y / relativeSize.x * maxPuzzleAreaSize.x);

            if (absoluteSize.x > maxPuzzleAreaSize.x)
                absoluteSize = new Vector2(maxPuzzleAreaSize.x, absoluteSize.y * (maxPuzzleAreaSize.x / absoluteSize.x)); 

            if (absoluteSize.y > maxPuzzleAreaSize.y)
                absoluteSize = new Vector2 (absoluteSize.x * (maxPuzzleAreaSize.y / absoluteSize.y), maxPuzzleAreaSize.y);
            

            float offsetX = (maxPuzzleAreaSize.x - absoluteSize.x) / (2 * maxPuzzleAreaSize.x); //relative distance between MaxPuzzleArea border and vertical PuzzleArea border
            Vector2 anchorX = new Vector2(offsetX ,  (1 - offsetX));
            float offsetY = (maxPuzzleAreaSize.y - absoluteSize.y) / (2 * maxPuzzleAreaSize.y); //relative distance between MaxPuzzleArea border and horizontal PuzzleArea border
            Vector2 anchorY = new Vector2(offsetY , (1 - offsetY));

            _rectTransform.anchorMin = new Vector2(anchorX.x, anchorY.x);
            _rectTransform.anchorMax = new Vector2(anchorX.y, anchorY.y);

            return absoluteSize;
        }
    }
}

