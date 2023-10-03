using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Line98
{
    public static class PathFinding
    {
        private const int MOVE_STRAIGHT_COST = 10;
        private const int MOVE_DIAGONAL_COST = 14;

        private static GridMap<Tile> _gridMap;

        private static List<Tile> _openList;
        private static List<Tile> _closeList;

        //public static PathFinding(GridMap<Tile> gridMap)
        //{
        //    _gridMap = gridMap;
        //}

        public static List<Tile> FindPath(int startX, int startY, int endX, int endY)
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
                    tile.TileData.GCost = int.MaxValue;
                    tile.TileData.CalculateFCost();
                    tile.Parents.TileData = null;
                }
            }

            startTile.TileData.GCost = 0;
            startTile.TileData.HCost = CalculateDistanceCost(startTile, endTile);
            startTile.TileData.CalculateFCost();

            while(_openList.Count > 0)
            {
                Tile currentTile = GetLowestFCost(_openList);

                if(currentTile == endTile)
                {
                    return GetPath(endTile);
                }

                _openList.Remove(currentTile);
                _closeList.Add(currentTile);

                List<Tile> neighbours = GetListNeighbours(currentTile);

                foreach (Tile neighbour in neighbours)
                {
                    if(_closeList.Contains(neighbour))
                    {
                        continue;
                    }

                    int tentativeGCost = currentTile.TileData.GCost + CalculateDistanceCost(currentTile, neighbour);

                    if(tentativeGCost < neighbour.TileData.GCost)
                    {
                        neighbour.Parents.TileData = currentTile.TileData;
                        neighbour.TileData.GCost = tentativeGCost;
                        neighbour.TileData.HCost = CalculateDistanceCost(neighbour, endTile);
                        neighbour.TileData.CalculateFCost();

                        if(!_openList.Contains(neighbour))
                        {
                            _openList.Add(neighbour);
                        }    
                    }
                }    
            }

            return _openList;
        }

        private static List<Tile> GetListNeighbours(Tile currentTile)
        {
            List<Tile> neighbours = new List<Tile>();

            if(currentTile.TileData.Row - 1 >= 0)
            {
                neighbours.Add(GetCurrentTile(currentTile.TileData.Row - 1, currentTile.TileData.Col));

                if(currentTile.TileData.Col - 1 >= 0)
                {
                    neighbours.Add(GetCurrentTile(currentTile.TileData.Row - 1, currentTile.TileData.Col - 1));
                }

                if(currentTile.TileData.Col + 1 < _gridMap.Height)
                {
                    neighbours.Add(GetCurrentTile(currentTile.TileData.Row - 1, currentTile.TileData.Col + 1));
                }
            }
            
            if(currentTile.TileData.Row + 1 < _gridMap.Width)
            {
                neighbours.Add(GetCurrentTile(currentTile.TileData.Row + 1, currentTile.TileData.Col));

                if (currentTile.TileData.Col - 1 >= 0)
                {
                    neighbours.Add(GetCurrentTile(currentTile.TileData.Row + 1, currentTile.TileData.Col - 1));
                }

                if (currentTile.TileData.Col + 1 < _gridMap.Height)
                {
                    neighbours.Add(GetCurrentTile(currentTile.TileData.Row + 1, currentTile.TileData.Col + 1));
                }
            }

            if(currentTile.TileData.Col - 1 >= 0)
            {
                neighbours.Add(GetCurrentTile(currentTile.TileData.Row, currentTile.TileData.Col - 1));
            }
            
            if(currentTile.TileData.Col + 1 < _gridMap.Height)
            {
                neighbours.Add(GetCurrentTile(currentTile.TileData.Row, currentTile.TileData.Col + 1));
            }

            return neighbours;
        }

        private static Tile GetCurrentTile(int row, int col)
        {
            return _gridMap.GetTileByIndex(row, col);
        }

        private static int CalculateDistanceCost(Tile a, Tile b)
        {
            int xDistance = Mathf.Abs(a.TileData.Row -  b.TileData.Row);
            int yDistance = Mathf.Abs(a.TileData.Col - b.TileData.Col);
            int remaining = Mathf.Abs(xDistance - yDistance);

            return MOVE_STRAIGHT_COST * remaining + MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance);
        }

        private static Tile GetLowestFCost(List<Tile> tiles)
        {
            Tile lowestTile = tiles[0];

            for(int i = 0; i < tiles.Count;i++)
            {
                if (tiles[i].TileData.FCost < lowestTile.TileData.FCost)
                {
                    lowestTile = tiles[i];
                }    
            }

            return lowestTile;
        }

        private static List<Tile> GetPath(Tile endTile)
        {
            List<Tile> path = new List<Tile>();
            path.Add(endTile);
            Tile currentTile = endTile;
            int i = 0;
            while (currentTile.Parents != null) 
            {
                i++;
                Debug.Log("Tile " + i + ": " + currentTile.Parents.TileData.Row + " " + currentTile.Parents.TileData.Col);
                path.Add(currentTile.Parents);
                currentTile = currentTile.Parents;
            }
            path.Reverse();

            return path;
        }
    }
}
