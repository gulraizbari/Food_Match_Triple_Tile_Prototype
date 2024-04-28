using System.Collections.Generic;
using UnityEngine;

namespace TripleTileMatch.Data.Levels
{
    [CreateAssetMenu(fileName = "LevelDataList", menuName = "Core/Level/LevelsDataList", order = 0)]
    public class LevelsDataList : ScriptableObject
    {
        public List<LevelData> LevelDataList;
    }
}

