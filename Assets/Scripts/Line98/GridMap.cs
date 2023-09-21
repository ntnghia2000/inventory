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
        [SerializeField] private GameObject _tile;
        [SerializeField] private int _numberOfSize = 3;

        private SpriteRenderer _tileRb;

        private float _cellSize;

        private Tile[,] _gridMap;

        private void Start()
        {
            _tileRb = _tile.GetComponent<SpriteRenderer>();
            _cellSize = _tileRb.size.x;

            _gridMap = new Tile[_numberOfSize, _numberOfSize];
        }

        public void CreateGrid(Tile cell)
        {
            for(int i = 0; i < _gridMap.GetLength(0); i++)
            {
                for(int j = 0; j < _gridMap.GetLength(1); j++)
                {
                    _gridMap[i, j] = Instantiate(cell, GetWorldPosition(i, j), Quaternion.identity);
                }
            }
        }

        private Vector3 GetWorldPosition(int width, int heigth) 
        {
            return new Vector3(width, heigth, 0) * _cellSize;
        }

        private void GetXY(Vector3 worldPos, out int x, out int y)
        {
            x = Mathf.FloorToInt(worldPos.x / _cellSize);
            y = Mathf.FloorToInt(worldPos.y / _cellSize);
        }

        public void SetColour(int i, int j, Color color) 
        {
            _gridMap[i, j].SetColour(color);
        }

        public void SetColorValue(Vector3 worldPos, Color color)
        {
            int x, y;
            GetXY(worldPos, out x, out y);
            SetColour(y, x, color);
        }    
    }
}
