namespace TripleTileMatch
{
    public class Constants
    {
        public struct LevelConstants
        {
            public static readonly string CurrentLevelNumber = "CURRENT_LEVEL_NUMBER";
            public static readonly string LevelComplete = "LEVEL_COMPLETE";
        }
        
        public struct SpawnTileConstants
        {
            public static readonly float SpawnXRange = 1.75f;
            public static readonly float SpawnZRange = 5.0f;
            public static readonly float YOffset = 1.5f;
        }

        public struct SoundStatusConstants
        {
            public static readonly string SoundFXStatus = "SOUNDFX_STATUS";
        }

        public struct MusicStatusConstants
        {
            public static readonly string MusicStatus = "MUSIC_STATUS";
        }
    }
}