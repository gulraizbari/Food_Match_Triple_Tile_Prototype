using UnityEngine;

namespace TripleTileMatch.Interfaces
{
    public interface IUIController
    {
        public void Initialize();

        public void EnableSettingsMenu(GameObject settingsMenu);

        public void LoadGameScene(int gameSceneIndex);

        public void ReloadScene();

        public void PlayButtonClickSFX();
    }
}