using TMPro;
using TripleTileMatch.Interfaces;
using TripleTileMatch.Utils.Prefs;
using UnityEngine;
using UnityEngine.UI;

namespace TripleTileMatch.Views
{
    public class UIView : MonoBehaviour, IUIView
    {
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _levelCompletePanel;
        [SerializeField] private GameObject _levelFailPanel;
        [SerializeField] private GameObject _settingsMenuPanel;
        [SerializeField] private Button _settingsMenuButton;
        [SerializeField] private TextMeshProUGUI _levelNumberText;
        
        public IUIController UIControllerHandler { get; set; }
        private LevelPrefsHandler.CurrentLevelPrefs _currentLevelPrefs;
        
        // ask
        
        // private void Start()
        // {
        //     if (_levelStatusPrefs.GetLevelStatus() == 1)
        //     {
        //         EnableLevelCompletePanel();
        //     }
        //     else if (_levelStatusPrefs.GetLevelStatus() == 2)
        //     {
        //         EnableLevelFailPanel();
        //     }
        //     else 
        //     {
        //         EnableMainMenuPanel();
        //     }
        // }

        public void InitializeView()
        {
            _currentLevelPrefs = new LevelPrefsHandler.CurrentLevelPrefs();
            SetActiveState(true);
            Debug.Log("UI View is initialized.");
            AssignCurrentLevelNumberText();
            RegisterSettingsButton();
        }

        private void OnDisable()
        {
            UnRegisterSettingsButton();
        }

        private void SetActiveState(bool state)
        {
            gameObject.SetActive(state);
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
            _settingsMenuButton.onClick.AddListener(EnableSettingsMenuPanel);
        }

        public void UnRegisterSettingsButton()
        {
            _settingsMenuButton.onClick.RemoveListener(EnableSettingsMenuPanel);
        }

        private void EnableSettingsMenuPanel()
        {
            UIControllerHandler.EnableSettingsMenu(_settingsMenuPanel);
        }
    }
}

