using TripleTileMatch.Interfaces;
using TripleTileMatch.Utils.Prefs;
using UnityEngine;

namespace TripleTileMatch.Controllers
{
    public class AudioController : BaseMenuModule, IAudioController
    {
        public IAudioView AudioViewHandler { get; set; }
        private AudioPrefsHandler _audioPrefsHandler;
        
        public override void Initialize()
        {
            _audioPrefsHandler = new AudioPrefsHandler();
            base.Initialize();
            Debug.Log("Audio Controller has been Initialized!");
            AudioViewHandler.InitializeView();
        }

        public void ToggleSound()
        {
            if (_audioPrefsHandler.GetSoundStatus() == 1)
            {
                _audioPrefsHandler.SetSoundStatus(0);
            }
            else
            {
                _audioPrefsHandler.SetSoundStatus(1);
            }
        }

        public void ToggleVibration()
        {
            throw new System.NotImplementedException();
        }
    }
}

