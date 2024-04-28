using System.Collections.Generic;
using TripleTileMatch.Data;
using TripleTileMatch.Data.Levels;
using TripleTileMatch.Interfaces;
using TripleTileMatch.Utils.Prefs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TripleTileMatch.Controllers
{
    public class TilesContainer : MonoBehaviour, ITileContainer
    {
        [SerializeField] private LevelsDataList _levelsDataList;
        [SerializeField] private TilesData _tilesData;
        [SerializeField] private Transform _tilesContainer;
        
        private List<TileDataModel> _tilesList;
        private LevelPrefsHandler.CurrentLevelPrefs _currentLevelPrefs;
        private float _spawnXRange = Constants.SpawnTileConstants.SpawnXRange;
        private float _spawnZRange = Constants.SpawnTileConstants.SpawnZRange;
        private float _yOffset = Constants.SpawnTileConstants.YOffset;
        private int _numberOfTiles;

        private void Start()
        {
            _currentLevelPrefs = new LevelPrefsHandler.CurrentLevelPrefs();
            _tilesList = new List<TileDataModel>();
            LoadTiles();
        }

         public void LoadTiles()
         {
             _numberOfTiles = GetNumberOfTilesToSpawn();
             for (int index = 0; index < _numberOfTiles; index++)
             {
                 SpawnRandomTile(index);
             }
         }

         private void SpawnRandomTile(int index)
         {
             var tile = _tilesData.TilesDataList[index];
             var tileAsset = LoadAssetAtPath(tile.Name);
             var randomPosition = GenerateRandomSpawnPosition();
             var tileInstance = Instantiate(tileAsset, randomPosition, Quaternion.identity, _tilesContainer);
             tileInstance.Initialize(new TileDataModel()
             {
                 Name = tile.Name,
                 Sprite = tile.Sprite,
                 Position = tileInstance.gameObject.transform,
             });
             _tilesList.Add(tileInstance);
         }

         private Vector3 GenerateRandomSpawnPosition()
        {
            float randomX = Random.Range(-_spawnXRange, _spawnXRange);
            float randomZ = Random.Range(-_spawnZRange, _spawnZRange);
            Vector3 randomSpawnPoint = new Vector3(randomX, _yOffset, randomZ);
            return randomSpawnPoint;
        }

        private int GetNumberOfTilesToSpawn()
        {
            var levelDataList = _levelsDataList.LevelDataList;
            var currentLevelNumber = _currentLevelPrefs.GetCurrentLevelNumber();
            var currentLevelDataIndex = currentLevelNumber - 1;
            _numberOfTiles = levelDataList[currentLevelDataIndex].NumberOfTiles;
            return _numberOfTiles;
        }

        private TileDataModel LoadAssetAtPath(string path)
        {
            var asset = Resources.Load<TileDataModel>("Fruits/" + path);
            return asset;
        }
        
        public List<TileDataModel> GetTilesList()
        {
            return _tilesList;
        }

        public TileDataModel GetTileAtIndex(int index)
        {
            return _tilesList[index];
        }
    }
}

