using TripleTileMatch.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TripleTileMatch.Controllers
{
    public class UIController : BaseMenuModule, IUIController
    {
        public IUIView UIViewHandler { get; set; }
        public ILevelController LevelControllerHandler { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("UI Controller has been initialized!");
            UIViewHandler.InitializeView();
        }
        
        public void EnableSettingsMenu(GameObject settingsPanel)
        {
            settingsPanel.SetActive(true);
        }

        public void LoadGameScene(int gameSceneIndex)
        {
            LevelControllerHandler.LoadScene(gameSceneIndex);
        }

        public void ReloadScene()
        {
            LevelControllerHandler.ReloadScene();
        }

    }
}
