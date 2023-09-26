using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Line98
{
    public interface ITile
    {
        bool IsPassable { get; set; }
        int GCost { get; set; }
        int HCost { get; set; }
        int FCost { get;}
        int Col { get; set; } 
        int Row { get; set; }

        void GatherElements(Vector3 tilePosition, GameObject tileObject, GameObject innerObject,
            GameObject textContainer, TextMeshPro gCost, TextMeshPro hCost, TextMeshPro fCost)
        { }
    }

    public class Tile: ITile
    {
        private Tile _parent;
        private int _gCost = 0;
        private int _hCost = 0;
        private int _fCost = 0;
        private bool _isPassable = false;
        private int _col = 0;
        private int _row = 0;
        private Vector3 _tilePosition;

        private GameObject _tileGameObject = new GameObject();
        private GameObject _textContainer= new GameObject();
        private SpriteRenderer _innerObject = new SpriteRenderer();
        private TextMeshPro _gCostTMP;
        private TextMeshPro _hCostTMP;
        private TextMeshPro _fCostTMP;
        private Color _tileColor = new Color();

        public Tile() 
        {
            _gCost = _hCost = _fCost = 0;
            _isPassable = false;
            _col = _row = 0;
        }

        public Tile(int row, int col)
        {
            _gCost = _hCost = _fCost = 0;
            _isPassable = false;
            _row = row;
            _col = col;
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

        public int Col
        {
            get => _col;
            set { _col = value; }
        }

        public int Row
        {
            get => _row;
            set { _row = value; }
        }

        public int FCost
        {
            get => _fCost;
        }

        public int CalculateFCost()
        {
            return _gCost + _hCost;
        }

        public void GatherElements(Vector3 tilePosition, GameObject tileObject, GameObject innerObject,
            GameObject textContainer, TextMeshPro gCost, TextMeshPro hCost, TextMeshPro fCost)
        {
            _tilePosition = tilePosition;
            _tileGameObject = GameObject.Instantiate(tileObject, _tilePosition, Quaternion.identity);
            _innerObject = innerObject.GetComponent<SpriteRenderer>();
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

        public Tile Parent
        {
            get => _parent;
            set { _parent = value; }
        }
    }
}
