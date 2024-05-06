using System.Collections.Generic;
using TripleTileMatch.Core;

namespace TripleTileMatch.Interfaces
{
    public interface IMergingTray
    {
        public List<HoldingPoint> GetHoldingPointsList();

        public void AddToHoldingPointsList(HoldingPoint holdingPoint);

        public List<Tile> GetContainedTilesList();
        
        public void UpdateGridOnSelection(Tile currentSelectedObject);

        public void AddToContainedTilesList(Tile selectableObject);
    }
}

