using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

namespace Line98
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _tile;
        [SerializeField] private Tile _cell;
        [SerializeField] private int _boardSize = 3;

        private GridMap _grid;

        private SpriteRenderer _tileRb;
        private float _tileSize = 0;

        void Start()
        {
            _tileRb = _tile.GetComponent<SpriteRenderer>();
            _tileSize = _tileRb.size.x;

            _grid = new GridMap(_boardSize, _tileSize);
            _grid.createGrid(_cell);
        }
    }
}
