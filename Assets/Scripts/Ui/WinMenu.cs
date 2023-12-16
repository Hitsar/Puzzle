using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class WinMenu : MonoBehaviour
    {
        private Vector2 _startPosition;

        private void OnEnable() => transform.DOLocalMoveY(0, 0.8f).SetEase(Ease.OutCubic);

        public void ToMenu()
        {
            transform.localPosition = _startPosition;
            SceneManager.LoadScene(0);
            gameObject.SetActive(false);
        }
    }
}