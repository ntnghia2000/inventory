using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using UnityEngine.Diagnostics;

namespace Line98
{
    public class GridMap: MonoBehaviour
    {
        private float _cellSize;
        private Tile[,] _gridMap;

        public GridMap(int value, float cellSize)
        {
            _cellSize = cellSize;
            _gridMap = new Tile[value, value];
        }

        public void createGrid(Tile cell)
        {
            for(int i = 0; i < _gridMap.GetLength(0); i++)
            {
                for(int j = 0; j < _gridMap.GetLength(1); j++)
                {
                    _gridMap[i, j] = Instantiate(cell, getWorldPosition(i, j), Quaternion.identity);
                }
            }
        }

        private Vector3 getWorldPosition(int width, int heigth) 
        {
            return new Vector3(width, heigth, 0) * _cellSize;
        }

        public void setColour(int i, int j, Color color) 
        {
            _gridMap[i, j].setColour(color);
        }
    }
}
