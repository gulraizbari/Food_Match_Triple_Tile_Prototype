using TripleTileMatch.Controllers;
using UnityEngine;

namespace TripleTileMatch.Core.DependencyInjector
{
    public class GameDependencyInjector: BaseDependencyInjector
    {
        [SerializeField] private TilesContainer _tilesContainer;
        [SerializeField] private MergingTray _mergingTray;

        public override void InjectDependencies()
        {
            _tilesContainer.MergingTrayHandler = _mergingTray;
            _mergingTray.TileContainerHandler = _tilesContainer;
        }
    }
}