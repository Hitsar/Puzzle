using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Ui
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Toggle _musicToggle, _soundToggle;

        private void Awake()
        {
            _musicToggle.onValueChanged.AddListener(SetMutedMusic);
            _soundToggle.onValueChanged.AddListener(SetMutedSound);

            if (_audioMixer.GetFloat("Music", out float volumeMusic) && volumeMusic < 0) 
                _musicToggle.isOn = true;

            if (_audioMixer.GetFloat("Sound", out float volumeSound) && volumeSound < 0) 
                _soundToggle.isOn = true;
        }

        private void SetMutedMusic(bool isMuted)
        {
            if (isMuted) 
                _audioMixer.SetFloat("Music", -80);
            else 
                _audioMixer.SetFloat("Music", 0);
        }
        
        private void SetMutedSound(bool isMuted)
        {
            if (isMuted) _audioMixer.SetFloat("Sound", -80);
            else _audioMixer.SetFloat("Sound", 0);
        }
    }
}