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
    public class GridMap<T> where T : ITile
    {
        private T[,] _gridMap;
        private float _tileSize;
        private int _width = 0;
        private int _height = 0;

        public GridMap(int width, int height, float tileSize, Func<int, int, T> CreateTile)
        {
            _tileSize = tileSize;

            _width = width;
            _height = height;
            _gridMap = new T[height, width];

            for (int i = 0; i < _gridMap.GetLength(0); i++)
            {
                for (int j = 0; j < _gridMap.GetLength(1); j++)
                {
                    _gridMap[i, j] = CreateTile(i, j);
                }
            }
        }

        private Vector3 GetWorldPosition(int width, int heigth)
        {
            return new Vector3(width, heigth, 0) * _tileSize;
        }

        public void GetXY(Vector3 worldPos, ref int x, ref int y)
        {
            x = Mathf.FloorToInt(worldPos.x / _tileSize);
            y = Mathf.FloorToInt(worldPos.y / _tileSize);
        }

        public T GetTileByIndex(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                return _gridMap[x, y];
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid indices.");
            }
        }

        public int Width 
        {
            get => _width;
            set => _width = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public T[,] GripMap
        {
            get => _gridMap;
        }
    }
}
