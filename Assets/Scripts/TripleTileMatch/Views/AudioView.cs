using TripleTileMatch.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace TripleTileMatch.Views
{
    public class AudioView: MonoBehaviour, IAudioView
    {
        [SerializeField] private GameObject _settingsMenuPanel;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _toggleSoundFXButton;
        [SerializeField] private Button _toggleMusicButton;
        [SerializeField] private Image _soundFXToggleImage;
        [SerializeField] private Image _backgroundMusicToggleImage;
        [SerializeField] private Sprite _toggleON;
        [SerializeField] private Sprite _toggleOFF;

        public IAudioController AudioControllerHandler { get; set; }

        public void InitializeView()
        {
            RegisterBackgroundMusicToggle();
            RegisterSoundFXToggle();
            RegisterCloseButton();
            SetActiveState(true);
        }

        private void OnDisable()
        {
            UnRegisterSoundToggle();
            UnRegisterBackgroundMusicToggle();
            UnRegisterCloseButton();
        }

        private void SetActiveState(bool state)
        {
            gameObject.SetActive(state);
        }

        public void RegisterSoundFXToggle()
        {
            UnRegisterSoundToggle();
            _toggleSoundFXButton.onClick.AddListener(OnToggleSoundFX);
        }

        public void RegisterBackgroundMusicToggle()
        {
            UnRegisterBackgroundMusicToggle();
            _toggleMusicButton.onClick.AddListener(OnToggleBackgroundMusic);
        }

        private void OnToggleSoundFX()
        {
            AudioControllerHandler.ToggleSoundFX();
        }

        private void OnToggleBackgroundMusic()
        {
            AudioControllerHandler.ToggleBackgroundMusic();
        }

        public void UnRegisterSoundToggle()
        {
            _toggleSoundFXButton.onClick.RemoveListener(OnToggleSoundFX);
        }

        public void UnRegisterBackgroundMusicToggle()
        {
            _toggleMusicButton.onClick.RemoveListener(OnToggleBackgroundMusic);
        }

        public void ToggleOnSoundFXButtonSprite()
        {
            _soundFXToggleImage.sprite = _toggleON;
        }

        public void ToggleOffSoundFXButtonSprite()
        {
            _soundFXToggleImage.sprite = _toggleOFF;
        }

        public void ToggleMusicOnButtonSprite()
        {
            _backgroundMusicToggleImage.sprite = _toggleON;
        }

        public void ToggleMusicOffButtonSprite()
        {
            _backgroundMusicToggleImage.sprite = _toggleOFF;
        }

        public void RegisterCloseButton()
        {
            UnRegisterCloseButton();
            _closeButton.onClick.AddListener(DisableSettingsMenuPanel);
        }

        public void UnRegisterCloseButton()
        {
            _closeButton.onClick.RemoveListener(DisableSettingsMenuPanel);
        }

        private void DisableSettingsMenuPanel()
        {
            AudioControllerHandler.DisableSettingsMenu(_settingsMenuPanel);
        }
    }
}