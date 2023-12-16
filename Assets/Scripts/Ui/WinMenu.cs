using DG.Tweening;
using UnityEngine;

namespace Ui
{
    public class WinMenu : MonoBehaviour
    {
        private Vector2 _startPosition;

        private void OnEnable() => transform.DOLocalMoveY(0, 0.8f).SetEase(Ease.OutCubic);

        private void OnDisable() => transform.localPosition = _startPosition;
    }
}