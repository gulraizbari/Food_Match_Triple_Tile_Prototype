using UnityEngine;

namespace TripleTileMatch.Interfaces
{
    public interface IUIController
    {
        public void Initialize();

        public void EnableSettingsMenu(GameObject settingsMenu);
    }
}