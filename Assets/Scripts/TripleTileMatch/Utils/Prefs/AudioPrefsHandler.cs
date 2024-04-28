using UnityEngine;

namespace TripleTileMatch.Utils.Prefs
{
    public class AudioPrefsHandler
    {
        public int GetSoundStatus()
        {
            var soundStatus = PlayerPrefs.GetInt(Constants.SoundStatusConstants.SoundStatus);
            return soundStatus;
        }

        public void SetSoundStatus(int status)
        {
            PlayerPrefs.SetInt(Constants.SoundStatusConstants.SoundStatus, status);
        }

        public int GetVibrationStatus()
        {
            var vibrationStatus = PlayerPrefs.GetInt(Constants.VibrationStatusConstants.VibrationStatus);
            return vibrationStatus;
        }

        public void SetVibrationStatus(int status)
        {
            PlayerPrefs.SetInt(Constants.VibrationStatusConstants.VibrationStatus, status);
        }
    }
}