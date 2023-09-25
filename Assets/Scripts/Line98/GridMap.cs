using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using UnityEngine.Diagnostics;
using static UnityEngine.Rendering.DebugUI;
using TMPro;
using static UnityEngine.Rendering.DebugUI.Table;

namespace Line98
{
    public class GridMap
    {
        private Tile[,] _gridMap;

        private float _tileSize;
        private int _width = 0;
        private int _height = 0;

        public GridMap(int width, int height, float tileSize)
        {
            _tileSize = tileSize;

            _width = width;
            _height = height;
            _gridMap = new Tile[width, height];

            for (int i = 0; i < _gridMap.GetLength(0); i++)
            {
                for (int j = 0; j < _gridMap.GetLength(1); j++)
                {
                    _gridMap[i, j] = new Tile(i, j);
                }
            }
        }

        private Vector3 GetWorldPosition(int width, int heigth)
        {
            return new Vector3(width, heigth, 0) * _tileSize;
        }

        public void GetXY(Vector3 worldPos, out int x, out int y)
        {
            x = Mathf.FloorToInt(worldPos.x / _tileSize);
            y = Mathf.FloorToInt(worldPos.y / _tileSize);
        }

        public void SetValue(int x, int y, int gCost, int hCost)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                _gridMap[x, y].GCost = gCost;
                _gridMap[x, y].HCost = hCost;
            }
        }

        public void SetValue(Vector3 worldPos, int gCost, int hCost)
        {
            int x, y;
            GetXY(worldPos, out x, out y);
            SetValue(x, y, gCost, hCost);
        }

        public Tile GetTileByIndex(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                return _gridMap[x, y].GetTile();
            }

            return null;
        }

        public int Width 
        {
            get => _width;
        }

        public int Height
        {
            get => _height;
        }

        public Tile[,] GripMap
        {
            get => _gridMap;
        }

        public void CreateObjectOnTile(GameObject tileGameObject, GameObject innerObject,
            GameObject textContainer, TextMeshPro gCost, TextMeshPro hCost, TextMeshPro fCos)
        {
            for (int i = 0; i < _gridMap.GetLength(0); i++)
            {
                for (int j = 0; j < _gridMap.GetLength(1); j++)
                {
                    _gridMap[i, j].GatherElements(GetWorldPosition(i, j), tileGameObject, innerObject, textContainer, gCost, hCost, fCos);
                }
            }
        }
    }
}
