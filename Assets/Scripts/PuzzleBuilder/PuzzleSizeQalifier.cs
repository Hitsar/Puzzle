using System.Collections.Generic;
using UnityEngine;

namespace PuzzleBuilder
{
    public class PuzzleSizeQualifier
    {
        public Vector2 GetMinMaxSize(List<Vector2> puzzleSizes)
        {
            if (puzzleSizes.Count == 0)
            {
                Debug.LogError("No sprites in list");
                return Vector2.zero;
            }

            float minSize = puzzleSizes[0].x < puzzleSizes[0].y ? puzzleSizes[0].x : puzzleSizes[0].y;
            float maxSize = puzzleSizes[0].x > puzzleSizes[0].y ? puzzleSizes[0].x : puzzleSizes[0].y;

            for (int i = 0; i < puzzleSizes.Count; i++)
            {
                if (puzzleSizes[i].x < minSize)
                    minSize = puzzleSizes[i].x;
                else if (puzzleSizes[i].y < minSize)
                    minSize = puzzleSizes[i].y;
                else if (puzzleSizes[i].x > maxSize)
                    maxSize = puzzleSizes[i].x;
                else if (puzzleSizes[i].y > maxSize)
                    maxSize = puzzleSizes[i].y;
            }

            return new Vector2(minSize, maxSize);
        }

        public Vector2 GetMinMaxSize(List<SketchPiece> puzzlePieces)
        {
            List<Vector2> puzzleSizes = new List<Vector2>();
            foreach (var piece in puzzlePieces)
                puzzleSizes.Add(piece.RectTransform.sizeDelta);

            return GetMinMaxSize(puzzleSizes);
        }

        public Vector2 GetMinMaxSize(List<Sprite> puzzleSprites)
        {
            List<Vector2> puzzleSizes = new List<Vector2>();
            foreach (var piece in puzzleSprites)
                puzzleSizes.Add(piece.rect.size);

            return GetMinMaxSize(puzzleSizes);
        }
    }
}

