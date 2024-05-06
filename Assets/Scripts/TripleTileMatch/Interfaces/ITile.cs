using TripleTileMatch.Controllers;
using TripleTileMatch.Core;
using TripleTileMatch.Data;
using UnityEngine;

namespace TripleTileMatch.Interfaces
{
    public interface ITile
    {
        public void Initialize(TileDataModel tileDataModel);

        public void SetTileContainer(TilesContainer tilesContainer);

        public string GetName();

        public Sprite GetSprite();

        public Transform GetTransform();

        public TileDataModel.TileType GetTileType();

        public void SetTileType(TileDataModel.TileType tileType);
        
        public void GridPlacementAnimation(HoldingPoint holdingPoint);
    }
}