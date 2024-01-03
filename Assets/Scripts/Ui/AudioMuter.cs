using Assets.Scripts.TagComponents.Audio;
using TagComponents.Audio;
using TagComponents.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

namespace Audio
{
    public class AudioMuter
    {
        private Toggle _musicToggle, _soundToggle;
        private AudioMixer _audioMixer;

        [Inject]
        public AudioMuter(MusicToggle musicToggle, SoundToggle soundToggle, AudioMixer audioMixer)
        {
            _musicToggle = musicToggle.Toggle;
            _soundToggle = soundToggle.Toggle;
            _audioMixer = audioMixer;

            _musicToggle.onValueChanged.AddListener(delegate { SetMutedMusic(_musicToggle); });
            _soundToggle.onValueChanged.AddListener(delegate { SetMutedSound(_soundToggle); });
        }

        //private void SetMutedMusic(Toggle change) => _musicAudioSource.volume = change.isOn ? 0f : 1f;
        private void SetMutedMusic(Toggle change)
        {
            Debug.Log(change.isOn);
            _audioMixer.SetFloat("Music", change.isOn ? -80 : 0);
        }

        private void SetMutedSound(Toggle change) => _audioMixer.SetFloat("Sound", change.isOn ? -80 : 0);
    }
}