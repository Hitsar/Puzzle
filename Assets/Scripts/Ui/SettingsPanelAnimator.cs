using DG.Tweening;
using UnityEngine;

namespace Ui
{
    public class SettingsPanelAnimator : MonoBehaviour
    {
        private void OnEnable() => transform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutCubic);
        public void HidePanel() => transform.DOLocalMoveY(1400, 0.6f).SetEase(Ease.InQuad).OnComplete(() => gameObject.SetActive(false));
    }
}