using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleBuilder
{
    public class PuzzleResizer : MonoBehaviour
    {
        public List<Vector2> ResizePuzzlePieces(List<Sprite> sprites, Vector2 puzzleAreaSize, Vector2 originalImageSize)
        {
            List<Vector2> result = new List<Vector2>();
            foreach (var piece in sprites) 
            {
                Vector2 pieceResize = new Vector2(piece.rect.width * puzzleAreaSize.x / originalImageSize.x, piece.rect.height * puzzleAreaSize.y / originalImageSize.y);
                result.Add(pieceResize);
                Debug.Log(pieceResize);
            }

            return result;
        }
    }
}

