using UnityEngine;

namespace TripleTileMatch.Interfaces
{
    public interface IAudioController
    {
        public void Initialize();

        public void ToggleSoundFX();

        public void ToggleBackgroundMusic();

        public void DisableSettingsMenu(GameObject settingsMenuPanel);

        public void PlayButtonClickSoundFX();
    }
}