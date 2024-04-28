namespace TripleTileMatch.Interfaces
{
    public interface IAudioView
    {
        public void InitializeView();

        public void RegisterSoundFXToggle();

        public void RegisterBackgroundMusicToggle();

        public void RegisterCloseButton();
        
        public void UnRegisterCloseButton();

        public void UnRegisterSoundToggle();

        public void UnRegisterBackgroundMusicToggle();

        public void ToggleOnSoundFXButtonSprite();

        public void ToggleOffSoundFXButtonSprite();

        public void ToggleMusicOnButtonSprite();

        public void ToggleMusicOffButtonSprite();
    }
}