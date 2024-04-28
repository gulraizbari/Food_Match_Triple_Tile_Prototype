using UnityEngine;

namespace TripleTileMatch.Data.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Core/Level/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public int NumberOfTiles;
        // public Dictionary<TileDataModel, int> MandatoryTiles;
        public float LevelCompletionTime;
        // public PowerUp PowerUp;
    }
}

