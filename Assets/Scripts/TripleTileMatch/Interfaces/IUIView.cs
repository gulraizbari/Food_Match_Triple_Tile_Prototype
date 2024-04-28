namespace TripleTileMatch.Interfaces
{
    public interface IUIView
    {
        public void InitializeView();
        
        public void EnableMainMenuPanel();

        public void EnableLevelCompletePanel();

        public void EnableLevelFailPanel();
    }
}