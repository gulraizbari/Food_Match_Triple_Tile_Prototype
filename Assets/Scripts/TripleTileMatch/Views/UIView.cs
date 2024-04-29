using TMPro;
using TripleTileMatch.Interfaces;
using TripleTileMatch.Utils.Prefs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TripleTileMatch.Views
{
    public class UIView : MonoBehaviour, IUIView
    {
        [Header("Panels")]
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _settingsMenuPanel;
        [SerializeField] private GameObject _levelCompletePanel;
        [SerializeField] private GameObject _levelFailPanel;
        [Header("Buttons")]
        [SerializeField] private Button _settingsMenuButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _retryButton;
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _levelNumberText;
        
        public IUIController UIControllerHandler { get; set; }
        private LevelPrefsHandler.CurrentLevelPrefs _currentLevelPrefs;
        private LevelPrefsHandler.LevelStatusPrefs _levelStatusPrefs;

        public void InitializeView()
        {
            _currentLevelPrefs = new LevelPrefsHandler.CurrentLevelPrefs();
            _levelStatusPrefs = new LevelPrefsHandler.LevelStatusPrefs();
            SetActiveState(true);
            Debug.Log("UI View is initialized.");
            LevelPanelStatus();
            AssignCurrentLevelNumberText();
            RegisterSettingsButton();
            RegisterPlayButton();
            RegisterNextButton();
            RegisterRetryButton();
        }

        private void OnDisable()
        {
            UnRegisterSettingsButton();
        }

        private void SetActiveState(bool state)
        {
            gameObject.SetActive(state);
        }

        public void LevelPanelStatus()
        {
            if (_levelStatusPrefs.GetLevelStatus() == 1)
            {
                EnableLevelCompletePanel();
            }
            else if (_levelStatusPrefs.GetLevelStatus() == 2)
            {
                EnableLevelFailPanel();
            }
            else 
            {
                EnableMainMenuPanel();
            }
        }

        private void AssignCurrentLevelNumberText()
        {
            var currentLevelNumber = _currentLevelPrefs.GetCurrentLevelNumber();
            SetLevelNumberText(currentLevelNumber);
        }

        private void SetLevelNumberText(int levelNumber)
        {
            _levelNumberText.text = levelNumber.ToString();
        }

        public void EnableMainMenuPanel()
        {
            _mainMenuPanel.SetActive(true);
            _levelCompletePanel.SetActive(false);
            _levelFailPanel.SetActive(false);
        }

        public void EnableLevelCompletePanel()
        {
            _mainMenuPanel.SetActive(false);
            _levelCompletePanel.SetActive(true);
        }

        public void EnableLevelFailPanel()
        {
            _mainMenuPanel.SetActive(false);
            _levelFailPanel.SetActive(true);
        }
        
        public void RegisterSettingsButton()
        {
            UnRegisterSettingsButton();
            _settingsMenuButton.onClick.AddListener(PlayButtonClickSFX);
            _settingsMenuButton.onClick.AddListener(EnableSettingsMenuPanel);
        }

        public void RegisterPlayButton()
        {
            UnRegisterPlayButton();
            _playButton.onClick.AddListener(PlayButtonClickSFX);
            _playButton.onClick.AddListener(DisableSettingsPanel);
            _playButton.onClick.AddListener(LoadGameScene);
        }

        public void RegisterNextButton()
        {
            UnRegisterNextButton();
            _nextButton.onClick.AddListener(PlayButtonClickSFX);
            _nextButton.onClick.AddListener(LoadGameScene);
        }

        public void RegisterRetryButton()
        {
            UnRegisterRetryButton();
            _retryButton.onClick.AddListener(PlayButtonClickSFX);
            _retryButton.onClick.AddListener(RetryButton);
        }

        public void UnRegisterSettingsButton()
        {
            _settingsMenuButton.onClick.RemoveListener(EnableSettingsMenuPanel);
        }
        
        public void UnRegisterPlayButton()
        {
            _playButton.onClick.RemoveListener(DisableSettingsPanel);
            _playButton.onClick.RemoveListener(LoadGameScene);
        }
        
        public void UnRegisterNextButton()
        {
            _nextButton.onClick.RemoveListener(LoadGameScene);
        }
        
        public void UnRegisterRetryButton()
        {
            _retryButton.onClick.RemoveListener(RetryButton);
        }

        private void LoadGameScene()
        {
            UIControllerHandler.LoadGameScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void RetryButton()
        {
            UIControllerHandler.ReloadScene();
        }
        
        private void DisableSettingsPanel()
        {
            _mainMenuPanel.SetActive(false);
        }

        private void PlayButtonClickSFX()
        {
            UIControllerHandler.PlayButtonClickSFX();
        }

        private void EnableSettingsMenuPanel()
        {
            UIControllerHandler.EnableSettingsMenu(_settingsMenuPanel);
        }
    }
}

