using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace Ui
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public void Audio(float value) => _audioMixer.SetFloat("Audio", value);
        public void Music(float value) => _audioMixer.SetFloat("Music", value);
        public void Sound(float value) => _audioMixer.SetFloat("Sound", value);

        private void OnEnable() => transform.DOLocalMoveY(0, 0.7f).SetEase(Ease.OutCubic);
        public void HidePanel() => transform.DOLocalMoveY(1400, 0.6f).SetEase(Ease.InQuad).OnComplete(() => gameObject.SetActive(false));
    }
}