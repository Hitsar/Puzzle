using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleBuilder
{
    public class PuzzleResizer : MonoBehaviour
    {
        public void ResizePuzzlePiece(SketchPiece sketchPiece, Vector2 puzzleAreaSize, Vector2 originalImageSize)
        {
            Vector2 pieceResize = new Vector2(sketchPiece.Sprite.rect.width * puzzleAreaSize.x / originalImageSize.x, sketchPiece.Sprite.rect.height * puzzleAreaSize.y / originalImageSize.y);
            sketchPiece.RectTransform.sizeDelta = pieceResize;
        }
    }
}

