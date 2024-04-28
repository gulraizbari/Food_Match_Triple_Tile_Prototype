using UnityEngine;

namespace TripleTileMatch.Utils.Prefs
{
    public class LevelPrefsHandler 
    {
        public class CurrentLevelPrefs
        {
            public void SetCurrentLevelNumber(int levelNumber)
            {
                PlayerPrefs.SetInt(Constants.LevelConstants.CurrentLevelNumber, levelNumber);
            }

            public int GetCurrentLevelNumber()
            {
                return PlayerPrefs.GetInt(Constants.LevelConstants.CurrentLevelNumber);
            }
        }

        public class LevelStatusPrefs
        {
            public void SetLevelStatus()
            {
                PlayerPrefs.SetInt(Constants.LevelConstants.LevelComplete, 0);
            }
        
            public void SetLevelComplete()
            {
                PlayerPrefs.SetInt(Constants.LevelConstants.LevelComplete, 1);
            }
    
            public void SetLevelFail()
            {
                PlayerPrefs.SetInt(Constants.LevelConstants.LevelComplete, 2);
            }

            public int GetLevelStatus()
            {
                var status = PlayerPrefs.GetInt(Constants.LevelConstants.LevelComplete);
                return status;
            }
        }
        
    }
}
