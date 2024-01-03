using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class SettingsPanelAnimator : MonoBehaviour
    {
        private void OnEnable() => ShowPanel();
        public void ShowPanel()
        {
            transform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutCubic);
            gameObject.SetActive(true);
        }
        public void HidePanel() => transform.DOLocalMoveY(1400, 0.6f).SetEase(Ease.InQuad).OnComplete(() => gameObject.SetActive(false));
    }
}