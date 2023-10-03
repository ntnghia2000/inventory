using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Line98
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private GameObject _tileObject;
        [SerializeField] private GameObject _textContainer;
        [SerializeField] private SpriteRenderer _innerObject;
        [SerializeField] private TextMeshPro _gCostTMP;
        [SerializeField] private TextMeshPro _hCostTMP;
        [SerializeField] private TextMeshPro _fCostTMP;

        private TileData _tileData;
        private Tile _parents;
        private Vector3 _tilePosition;

        public void InitData(int row, int col)
        {
            _tileData = new TileData(row, col);

            transform.position = _tilePosition;
        }

        public void SetColor(Color color)
        {
            _innerObject.color = color;
        }

        public TileData TileData
        {
            get { return _tileData; }
            set { _tileData = value; }
        }

        public Vector3 TilePosition
        {
            get => _tilePosition;
            set { _tilePosition = value; }
        }

        public Tile Parents
        {
            get => _parents;
            set { _parents = value; }
        }
    }
}