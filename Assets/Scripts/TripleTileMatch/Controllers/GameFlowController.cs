using System.Collections.Generic;
using TripleTileMatch.Interfaces;
using UnityEngine;

namespace TripleTileMatch.Controllers
{
    public class GameFlowController : MonoBehaviour, IGameFlowController
    {
        [SerializeField] private List<BaseMenuModule> _gameModulesList;

        private void Start()
        {
            _gameModulesList = new List<BaseMenuModule>();
            LoadModules();
        }

        public void LoadModules()
        {
            for (int index = 0; index < _gameModulesList.Count; index++)
            {
                var module = _gameModulesList[index];
                InitializeModule(module);
            }
        }

         public void InitializeModule(BaseMenuModule moduleAsset)
        {
            moduleAsset.Initialize();
        }
         
    }
}