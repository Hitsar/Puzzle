using DG.Tweening;
using UnityEngine;

namespace Puzzles
{
    public class PuzzleVfx
    {
        private readonly Transform _transform;

        public PuzzleVfx(Transform transform) => _transform = transform;

        public void MoveTo(Vector2 position)
        {
            _transform.DOScale(_transform.localScale / 1.6f, 0.3f).SetEase(Ease.OutBack);
            _transform.DOMove(position, 0.5f).SetEase(Ease.OutBack);
        }

        public void Select() => _transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }
}