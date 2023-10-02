using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Line98
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private GameObject _tileObject;
        [SerializeField] private GameObject _textContainer;
        [SerializeField] private SpriteRenderer _innerObject;
        [SerializeField] private TextMeshPro _gCostTMP;
        [SerializeField] private TextMeshPro _hCostTMP;
        [SerializeField] private TextMeshPro _fCostTMP;

        private Tile _tileData;
        private Vector3 _tilePosition;

        public void Init(Tile tileData)
        {
            _tileData = tileData;

            transform.position = _tilePosition;
        }

        public void SetColor(Color color)
        {
            _innerObject.color = color;
        }

        public Tile TileData
        {
            get { return _tileData; }
            set { _tileData = value; }
        }

        public Vector3 TilePosition
        {
            get => _tilePosition;
            set { _tilePosition = value; }
        }
    }
}