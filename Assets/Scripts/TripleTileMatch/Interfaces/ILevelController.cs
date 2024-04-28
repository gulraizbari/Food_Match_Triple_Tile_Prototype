namespace TripleTileMatch.Interfaces
{
    public interface ILevelController
    {
        public void Initialize();
        
        public void SetLevelStatus();
        
        public void SetLevelComplete();
        
        public void SetLevelFail();
        
        public void SetCurrentLevelNumber(int levelNumber);
        
        public int GetCurrentLevelNumber();

        public void LoadScene(int sceneIndex);

        public void ReloadScene();
    }
}