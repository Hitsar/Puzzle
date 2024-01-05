using DG.Tweening;
using UnityEngine;

namespace Puzzles
{
    public class PuzzleVfx
    {
        private Transform _transform;
        public void SetTransform(Transform transform) => _transform = transform;

        public void MoveTo(Vector2 position)
        {
            _transform.DOScale(_transform.localScale / 1.6f, 0.3f).SetEase(Ease.OutBack);
            _transform.DOMove(position, 0.5f).SetEase(Ease.OutBack).OnComplete(() => SetBarAsParent());
        }

        public void Select()
        {
            _transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        }

        private void SetBarAsParent()
        {
            Debug.Log("Animation complete");
        }
    }
}