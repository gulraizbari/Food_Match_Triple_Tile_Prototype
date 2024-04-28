using UnityEngine;

namespace TripleTileMatch.Utils.Prefs
{
    public class AudioPrefsHandler
    {
        public int GetSoundFXStatus()
        {
            var soundStatus = PlayerPrefs.GetInt(Constants.SoundStatusConstants.SoundFXStatus);
            return soundStatus;
        }

        public void SetSoundFXStatus(int status)
        {
            PlayerPrefs.SetInt(Constants.SoundStatusConstants.SoundFXStatus, status);
        }
        
        public int GetMusicStatus()
        {
            var soundStatus = PlayerPrefs.GetInt(Constants.MusicStatusConstants.MusicStatus);
            return soundStatus;
        }

        public void SetMusicStatus(int status)
        {
            PlayerPrefs.SetInt(Constants.MusicStatusConstants.MusicStatus, status);
        }
        
    }
}