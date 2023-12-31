using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class WinPanelAnimator : MonoBehaviour
    {
        private void OnEnable() => transform.DOLocalMoveY(0, 0.8f).SetEase(Ease.OutCubic);

        private void OnDisable() => transform.localPosition = Vector2.up * -1150;
    }
}