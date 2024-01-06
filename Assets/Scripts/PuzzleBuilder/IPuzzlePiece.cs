using UnityEngine;

namespace Puzzles
{
    public interface IPuzzlePiece
    {
        Sprite Sprite { get; }
        RectTransform RectTransform { get; }
    }
}