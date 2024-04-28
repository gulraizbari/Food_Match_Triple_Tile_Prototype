using TripleTileMatch.Interfaces;
using TripleTileMatch.Utils.Prefs;
using UnityEngine;
using UnityEngine.UI;

namespace TripleTileMatch.Views
{
    public class AudioView: MonoBehaviour, IAudioView
    {
        [SerializeField] private Button _toggleOnButton;
        [SerializeField] private Button _toggleOffButton;
        
        public IAudioController AudioControllerHandler { get; set; }
        private AudioPrefsHandler _audioPrefsHandler;
        
        public void InitializeView()
        {
            _audioPrefsHandler =  new AudioPrefsHandler();
            SetActiveState(true);
            RegisterToggle();
        }
        
        private void SetActiveState(bool state)
        {
            gameObject.SetActive(state);
        }

        public void RegisterToggle()
        {
            _toggleOnButton.onClick.AddListener(OnToggle);
        }

        private void OnToggle()
        {
            AudioControllerHandler.ToggleSound();
        }
    }
}