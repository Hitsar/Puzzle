using System.Collections.Generic;
using UnityEngine;

namespace PuzzleBuilder
{
    public class PuzzleSizeQualifier
    {
        public Vector2 GetMinMaxSize(List<Sprite> puzzleSprites)
        {
            if (puzzleSprites.Count == 0)
            {
                Debug.LogError("No sprites in list");
                return Vector2.zero;
            }

            float minSize = puzzleSprites[0].rect.width < puzzleSprites[0].rect.height ? puzzleSprites[0].rect.width : puzzleSprites[0].rect.height;
            float maxSize = puzzleSprites[0].rect.width > puzzleSprites[0].rect.height ? puzzleSprites[0].rect.width : puzzleSprites[0].rect.height;

            for (int i = 0; i < puzzleSprites.Count; i++)
            {
                if (puzzleSprites[i].rect.width < minSize)
                    minSize = puzzleSprites[i].rect.width;
                else if (puzzleSprites[i].rect.height < minSize)
                    minSize = puzzleSprites[i].rect.width;
                else if (puzzleSprites[i].rect.width > maxSize)
                    maxSize = puzzleSprites[i].rect.width;
                else if (puzzleSprites[i].rect.height > maxSize)
                    maxSize = puzzleSprites[i].rect.height;
            }

            return new Vector2(minSize, maxSize);
        }
    }
}

