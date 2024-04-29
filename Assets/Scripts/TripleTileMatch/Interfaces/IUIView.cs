namespace TripleTileMatch.Interfaces
{
    public interface IUIView
    {
        public void InitializeView();

        public void LevelPanelStatus();
        
        public void EnableMainMenuPanel();

        public void EnableLevelCompletePanel();

        public void EnableLevelFailPanel();

        public void RegisterSettingsButton();

        public void RegisterPlayButton();

        public void RegisterNextButton();

        public void UnRegisterSettingsButton();
        
        public void UnRegisterPlayButton();

        public void UnRegisterNextButton();
    }
}