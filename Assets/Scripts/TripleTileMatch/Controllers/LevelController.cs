using TripleTileMatch.Interfaces;
using TripleTileMatch.Utils.Prefs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TripleTileMatch.Controllers
{
    public class LevelController : BaseMenuModule, ILevelController
    {
        private LevelPrefsHandler.CurrentLevelPrefs _currentLevelPrefs;
        private LevelPrefsHandler.LevelStatusPrefs _levelStatusPrefs;

        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("Level Controller has been Initialized!");
            _currentLevelPrefs = new LevelPrefsHandler.CurrentLevelPrefs();
            _levelStatusPrefs = new LevelPrefsHandler.LevelStatusPrefs();
        }

        public void SetLevelStatus()
        {
            _levelStatusPrefs.SetLevelStatus();
        }
        
        public void SetLevelComplete()
        {
            _levelStatusPrefs.SetLevelComplete();
        }
    
        public void SetLevelFail()
        {
            _levelStatusPrefs.SetLevelFail();
        }

        public void SetCurrentLevelNumber(int levelNumber)
        {
            _currentLevelPrefs.SetCurrentLevelNumber(levelNumber);
        }

        public int GetCurrentLevelNumber()
        {
            var currentLevelNumber =  _currentLevelPrefs.GetCurrentLevelNumber();
            return currentLevelNumber;
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }

        public void ReloadScene()
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(currentSceneIndex);
        }
    }
}