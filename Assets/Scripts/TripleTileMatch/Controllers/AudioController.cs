using TripleTileMatch.Interfaces;
using TripleTileMatch.Utils.Prefs;
using UnityEngine;

namespace TripleTileMatch.Controllers
{
    public class AudioController : BaseMenuModule, IAudioController
    {
        [SerializeField] private AudioSource _buttonClickSoundFX;
        [SerializeField] private AudioSource _backgroundMusicAudioSource;

        public IAudioView AudioViewHandler { get; set; }
        private AudioPrefsHandler _audioPrefsHandler;
        
        public override void Initialize()
        {
            base.Initialize();
            _audioPrefsHandler = new AudioPrefsHandler();
            Debug.Log("Audio Controller has been Initialized!");
            _audioPrefsHandler.SetMusicStatus(1);
            _audioPrefsHandler.SetSoundFXStatus(1);
            AudioViewHandler.InitializeView();
            CheckMusicValue();
            CheckSoundFXValue();
        }

        public void ToggleSoundFX()
        {
            if (_audioPrefsHandler.GetSoundFXStatus() == 1)
            {
                _audioPrefsHandler.SetSoundFXStatus(0);
            }
            else
            {
                _audioPrefsHandler.SetSoundFXStatus(1);
            }

            CheckSoundFXValue();
        }

        private void CheckSoundFXValue()
        {
            if (_audioPrefsHandler.GetSoundFXStatus() == 1)
            {
                
                AudioViewHandler.ToggleOnSoundFXButtonSprite();
            }
            else
            {
                AudioViewHandler.ToggleOffSoundFXButtonSprite();
            }
        }

        public void ToggleBackgroundMusic()
        {
            if (_audioPrefsHandler.GetMusicStatus() == 1)
            {
                _audioPrefsHandler.SetMusicStatus(0);
            }
            else
            {
                _audioPrefsHandler.SetMusicStatus(1);
            }

            CheckMusicValue();
        }

        private void CheckMusicValue()
        {
            if (_audioPrefsHandler.GetMusicStatus() == 1)
            {
                EnableBackgroundMusic();
                AudioViewHandler.ToggleMusicOnButtonSprite();
            }
            else
            {
                DisableBackgroundMusic();
                AudioViewHandler.ToggleMusicOffButtonSprite();
            }
        }

        private void EnableBackgroundMusic() => _backgroundMusicAudioSource.Play();

        private void DisableBackgroundMusic() => _backgroundMusicAudioSource.Stop();
        
        public void PlayButtonClickSoundFX() => _buttonClickSoundFX.Play();

        public void DisableSettingsMenu(GameObject settingsMenuPanel)
        {
            settingsMenuPanel.SetActive(false);
        }
    }
}

