using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Line98
{
    interface ITile
    {
        bool IsPassable { get; set; }
        int GCost { get; set; }
        int HCost { get; set; }
        int FCost { get;}
        Vector3 TilePosition { get; set; }
    }

    public class Tile: ITile
    {
        private Tile parent;
        private int _gCost = 0;
        private int _hCost = 0;
        private int _fCost = 0;
        private bool _isPassable = false;
        private Vector3 _tilePosition;

        private GameObject _tileGameObject;
        private GameObject _textContainer;
        private SpriteRenderer _innerObject;
        private TextMeshPro _gCostTMP;
        private TextMeshPro _hCostTMP;
        private TextMeshPro _fCostTMP;
        private Color _tileColor;

        public Tile() 
        {
            _gCost = _hCost = _fCost = 0;
            _isPassable = false;
            _tilePosition = new Vector3(0, 0, 0);
            _tileGameObject = null;
        }

        public Tile(Vector3 tilePosition, GameObject tileObject, GameObject innerObject)
        {
            _gCost = _hCost = _fCost = 0;
            _isPassable = false;
            _tilePosition = tilePosition;
            _tileGameObject = GameObject.Instantiate(tileObject, _tilePosition, Quaternion.identity);
            _innerObject = innerObject.GetComponent<SpriteRenderer>();
        }

        public bool IsPassable
        {
            get { return _isPassable; }
            set 
            { 
                _isPassable = value;
            }
        }

        public int GCost
        {
            get => _gCost;
            set
            {
                _gCost = value;
                _gCostTMP.text = _gCost.ToString();
            }
        }

        public int HCost
        {
            get => _hCost;
            set
            {
                _hCost = value;
                _hCostTMP.text = _hCost.ToString();
            }
        }

        public int FCost
        {
            get => _fCost = _gCost + _hCost;
        }

        public void GatherElements(GameObject textContainer, TextMeshPro gCost, TextMeshPro hCost, TextMeshPro fCost)
        {
            _textContainer = textContainer;
            _gCostTMP = gCost;
            _hCostTMP = hCost;
            _fCostTMP = fCost;
        }

        public Vector3 TilePosition
        {
            get => _tilePosition;
            set { _tilePosition = value; }
        }

        public void SetColor(Color color)
        {
            _innerObject.color = color;
        }

        public Tile GetTile()
        {
            return this;
        }
    }
}
