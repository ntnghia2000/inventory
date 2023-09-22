using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using UnityEngine.Diagnostics;
using static UnityEngine.Rendering.DebugUI;

namespace Line98
{
    public class GridMap: MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _tileSR;
        [SerializeField] private Tile _tile;

        private Tile[,] _gridMap;

        private int _width = 0;
        private int _height = 0;

        public void CreateGrid(int width, int height)
        {
            _width = width;
            _height = height;

            _gridMap = new Tile[width, height];

            for (int i = 0; i < _gridMap.GetLength(0); i++)
            {
                for(int j = 0; j < _gridMap.GetLength(1); j++)
                {
                    _gridMap[i, j] = Instantiate(_tile, GetWorldPosition(i, j), Quaternion.identity);
                }
            }
        }

        private Vector3 GetWorldPosition(int width, int heigth) 
        {
            return new Vector3(width, heigth, 0) * _tileSR.size.x;
        }

        private void GetXY(Vector3 worldPos, out int x, out int y)
        {
            x = Mathf.FloorToInt(worldPos.x / _tileSR.size.x);
            y = Mathf.FloorToInt(worldPos.y / _tileSR.size.y);
        }    

        public void SetColor(int x, int y, Color color)
        {
            if(x >= 0 && y >= 0 && x < _width && y < _height)
            {
                _gridMap[x, y].SetTileColor(color);
            }    
        }
        
        public void SetColor(Vector3 worldPos, Color color)
        {
            int x, y;
            GetXY(worldPos, out x, out y);
            SetColor(x, y, color);
        }    
    }
}
