using UnityEngine;

namespace TripleTileMatch.Data
{
    [CreateAssetMenu(fileName = "TileDataModel", menuName = "Core/Tile", order = 0)]
    public class TileModel : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
    }
}
