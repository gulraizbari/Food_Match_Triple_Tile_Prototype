using System.Collections.Generic;
using TripleTileMatch.Core;
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

        private List<Tile> _tilesList;
        private LevelPrefsHandler.CurrentLevelPrefs _currentLevelPrefs;
        private float _spawnXRange = Constants.SpawnTileConstants.SpawnXRange;
        private float _spawnZRange = Constants.SpawnTileConstants.SpawnZRange;
        private float _yOffset = Constants.SpawnTileConstants.YOffset;
        private int _numberOfTiles;
        private int _iterator = 0;
        
        public IMergingTray MergingTrayHandler { get; set; }

        private void Start()
        {
            _currentLevelPrefs = new LevelPrefsHandler.CurrentLevelPrefs();
            _tilesList = new List<Tile>();
            LoadTiles();
        }

        public void LoadTiles()
        {
            var tileVariations = _tilesData.TilesDataList.Count;
            _numberOfTiles = GetNumberOfTilesToSpawn();
            for (int index = 0; index < _numberOfTiles; index++)
            {
                if (index % tileVariations == 0)
                {
                    _iterator = 0;
                }
                SpawnRandomTile(_iterator);
            }
        }

        private void SpawnRandomTile(int index)
        {
            var tile = _tilesData.TilesDataList[index];
            var tileAsset = LoadAssetAtPath(tile.Name);
            var randomPosition = GenerateRandomSpawnPosition();
            var tileInstance = Instantiate(tileAsset, randomPosition, tileAsset.transform.rotation, _tilesContainer);
            tileInstance.Initialize(new TileDataModel
            {
                Name = tile.Name,
                Sprite = tile.Sprite,
                Transform = tileInstance.gameObject.transform,
            });
            tileInstance.SetTileContainer(this);
            _tilesList.Add(tileInstance);
            _iterator++;
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

        public void UpdateMergingListOnTileSelection(Tile selectedTile)
        {
            MergingTrayHandler.UpdateGridOnSelection(selectedTile);
        }

        public Tile LoadAssetAtPath(string path)
        {
            var asset = Resources.Load<Tile>("Fruits/" + path);
            return asset;
        }

        public void RemoveTileAtIndex(int index)
        {
            if (index < 0 || index >= _tilesList.Count)
            {
                Debug.Log("Index out of bounds.");
            }
            _tilesList.RemoveAt(index);
        }

        public List<Tile> GetTilesList()
        {
            return _tilesList;
        }

        public int GetIndexOfTile(string name)
        {
            for (int index = 0; index < _tilesList.Count; index++)
            {
                if (_tilesList[index].GetName() == name)
                {
                    return index;
                }
            }
            return -1;
        }

        public Tile GetTileAtIndex(int index)
        {
            return _tilesList[index];
        }
    }
}