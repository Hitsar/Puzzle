using DG.Tweening;
using UnityEngine;

namespace Puzzles
{
    public class PuzzleVfx : MonoBehaviour
    {
        public void MoveTo(Vector2 position) => transform.DOMove(position, 0.5f).SetEase(Ease.OutBack);
        public void Select() => transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        public void Deselect() => transform.DOScale(transform.localScale / 1.6f, 0.3f).SetEase(Ease.OutBack);
    }
}