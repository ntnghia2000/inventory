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

        public PathFinding(int width, int height, float tileSize)
        {
            _gridMap = new GridMap(width, height, tileSize);
        }

        public void GatherElements(GameObject tileGameObject, GameObject innerObject,
            GameObject textContainer, TextMeshPro gCost, TextMeshPro hCost, TextMeshPro fCos)
        {
            _gridMap.CreateObjectOnTile(tileGameObject, innerObject, textContainer, gCost, hCost, fCos);
        }

        public Tile GetCurrentTile(int x, int y)
        {
            return _gridMap.GetTileByIndex(x, y);
        }

        public List<Tile> FindTile(int startX, int startY, int endX, int endY)
        {
            Tile startTile = _gridMap.GetTileByIndex(startX, startY);
            Tile endTile = _gridMap.GetTileByIndex(endX, endY);

            _openList = new List<Tile>() { startTile };
            _closeList = new List<Tile>();

            for(int i = 0; i < _gridMap.Width; i++)
            {
                for(int j = 0; j < _gridMap.Height; j++)
                {
                    Tile tile = _gridMap.GetTileByIndex(i, j);
                    tile.GCost = int.MaxValue;
                    tile.CalculateFCost();
                    tile.Parent = null;
                }
            }

            startTile.GCost = 0;
            startTile.HCost = CalculateDistanceCost(startTile, endTile);
            startTile.CalculateFCost();

            while(_openList.Count > 0)
            {
                Tile currentTile = GetLowestFCost(_openList);

                if(currentTile == endTile)
                {
                    return GetPath(endTile);
                }

                _openList.Remove(currentTile);
                _closeList.Add(currentTile);

                foreach(Tile neighbour in GetListNeighbours(currentTile))
                {
                    if(_closeList.Contains(neighbour))
                    {
                        continue;
                    }    

                    int tentativeGCost = currentTile.GCost + CalculateDistanceCost(currentTile, neighbour);

                    if(tentativeGCost < neighbour.GCost)
                    {
                        neighbour.Parent = currentTile;
                        neighbour.GCost = tentativeGCost;
                        neighbour.HCost = CalculateDistanceCost(neighbour, endTile);
                        neighbour.CalculateFCost();

                        if(!_openList.Contains(neighbour))
                        {
                            _openList.Add(neighbour);
                        }    
                    }
                }    
            }

            return _openList;
        }

        private List<Tile> GetListNeighbours(Tile currentTile)
        {
            List<Tile> neighbours = new List<Tile>();

            if(currentTile.Row - 1 >= 0)
            {
                neighbours.Add(GetCurrentTile(currentTile.Row - 1, currentTile.Col));

                if(currentTile.Col - 1 >= 0)
                {
                    neighbours.Add(GetCurrentTile(currentTile.Row - 1, currentTile.Col - 1));
                }

                if(currentTile.Col + 1 < _gridMap.Height)
                {
                    neighbours.Add(GetCurrentTile(currentTile.Row - 1, currentTile.Col + 1));
                }
            }
            
            if(currentTile.Row + 1 < _gridMap.Width)
            {
                neighbours.Add(GetCurrentTile(currentTile.Row + 1, currentTile.Col));

                if (currentTile.Col - 1 >= 0)
                {
                    neighbours.Add(GetCurrentTile(currentTile.Row - 1, currentTile.Col - 1));
                }

                if (currentTile.Col + 1 < _gridMap.Height)
                {
                    neighbours.Add(GetCurrentTile(currentTile.Row - 1, currentTile.Col + 1));
                }
            }

            if(currentTile.Col - 1 >= 0)
            {
                neighbours.Add(GetCurrentTile(currentTile.Row, currentTile.Col - 1));
            }
            
            if(currentTile.Col + 1 < _gridMap.Height)
            {
                neighbours.Add(GetCurrentTile(currentTile.Row, currentTile.Col + 1));
            }

            return neighbours;
        }

        private int CalculateDistanceCost(Tile a, Tile b)
        {
            int xDistance = Mathf.Abs(a.Row -  b.Row);
            int yDistance = Mathf.Abs(a.Col - b.Col);
            int remaining = Mathf.Abs(xDistance - yDistance);

            return MOVE_STRAIGHT_COST * remaining + MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance);
        }

        private Tile GetLowestFCost(List<Tile> tiles)
        {
            Tile lowestTile = tiles[0];

            for(int i = 0; i < tiles.Count;i++)
            {
                if (tiles[i].FCost < lowestTile.FCost)
                {
                    lowestTile = tiles[i];
                }    
            }

            return lowestTile;
        }

        private List<Tile> GetPath(Tile endTile)
        {
            List<Tile> path = new List<Tile>();
            path.Add(endTile);
            Tile currentTile = endTile;
            while (currentTile.Parent != null) 
            {
                path.Add(currentTile.Parent);
                currentTile = currentTile.Parent;
            }
            path.Reverse();

            return path;
        }

        public GridMap GetGrid()
        {
            return _gridMap;
        }
    }
}
