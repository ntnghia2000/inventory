using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Line98
{
    public class PathFinding
    {
        private const int MOVE_STRAIGHT_COST = 10;
        private const int MOVE_DIAGONAL_COST = 14;

        private GridMap _gridMap;
        private Tile _currentTile;

        private List<Tile> _openList;
        private List<Tile> _closeList;

        public PathFinding(int width, int height, float tileSize, GameObject tileGameObject, GameObject innerObject,
            GameObject textContainer, TextMeshPro gCost, TextMeshPro hCost, TextMeshPro fCos)
        {
            _gridMap = new GridMap(width, height, tileSize, tileGameObject, innerObject,
                textContainer, gCost, hCost, fCos);
        }

        public bool GetCurrentTile(int x, int y)
        {
            _currentTile = _gridMap.GetTileByIndex(x, y);

            return _currentTile.IsPassable;
        }

        public List<Tile> FindTile(int startX, int startY, int endX, int endY)
        {
            Tile startTile = _gridMap.GetTileByIndex(startX, startY);

            _openList = new List<Tile>() { startTile };
            _closeList = new List<Tile>();

            for(int i = 0; i < _gridMap.Width; i++)
            {
                for(int j = 0; j < _gridMap.Height; j++)
                {

                }    
            }    

            return _openList;
        }
    }
}
