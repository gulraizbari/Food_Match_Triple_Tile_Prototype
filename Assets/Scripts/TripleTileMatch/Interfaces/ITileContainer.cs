using System.Collections.Generic;
using TripleTileMatch.Core;

namespace TripleTileMatch.Interfaces
{
    public interface ITileContainer
    {
        public void LoadTiles();

        public Tile LoadAssetAtPath(string path);

        public void RemoveTileAtIndex(int index);

        public List<Tile> GetTilesList();

        public Tile GetTileAtIndex(int index);

        public int GetIndexOfTile(string name);
    }
}

