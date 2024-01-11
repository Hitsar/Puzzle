using UnityEngine;

namespace Puzzles
{
    public interface IPuzzleVFX
    {
        void SetTransform(Transform transform);
        void MoveTo(Vector2 position);
        void Select();
    }
}