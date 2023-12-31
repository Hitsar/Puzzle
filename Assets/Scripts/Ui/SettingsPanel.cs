using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace Ui
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public void Music(bool isMuted)
        {
            if (isMuted) _audioMixer.SetFloat("Music", -80);
            else _audioMixer.SetFloat("Music", 0);
        }
        
        public void Sound(bool isMuted)
        {
            if (isMuted) _audioMixer.SetFloat("Sound", -80);
            else _audioMixer.SetFloat("Sound", 0);
        }

        private void OnEnable() => transform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutCubic);
        public void HidePanel() => transform.DOLocalMoveY(1400, 0.6f).SetEase(Ease.InQuad).OnComplete(() => gameObject.SetActive(false));
    }
}