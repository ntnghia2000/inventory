using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Line98
{
    interface ITile
    {
        bool IsPassable { get; set; }
        int GCost { get; }
        int HCost { get; }
        int FCost { get;}
        Vector3 TilePosition { get; }
    }

    public class Tile: MonoBehaviour, ITile
    {
        [SerializeField] private SpriteRenderer _innerSR;
        [SerializeField] private GameObject _highlight;
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _unpassableColor;
        [SerializeField] private Color _passableColor;
        [SerializeField] private GameObject _costContainer;
        [SerializeField] private TextMeshPro _gCostTMP;
        [SerializeField] private TextMeshPro _hCostTMP;
        [SerializeField] private TextMeshPro _fCostTMP;

        private int _gCost = 0;
        private int _hCost = 0;
        private int _fCost = 0;

        private bool _isPassable = false;

        private void Start()
        {
            _innerSR.color = _innerSR.color != _baseColor ? _innerSR.color : _baseColor;
        }

        public bool IsPassable
        {
            get { return _isPassable; }
            set 
            { 
                _isPassable = value;
                _innerSR.color = _isPassable ? _passableColor : _unpassableColor;
            }
        }

        public int GCost
        {
            get => _gCost;
        }

        public int HCost
        {
            get => _hCost;
        }

        public int FCost
        {
            get => _fCost;
        }

        public Vector3 TilePosition
        {
            get => transform.position;
        }    

        public void SetActiveTMP(bool isActive)
        {
            _gCostTMP.text = GCost.ToString();
            _hCostTMP.text = HCost.ToString();
            _fCostTMP.text = FCost.ToString();
            _costContainer.SetActive(isActive);
        }

        public void SetValues(int gCost, int hCost)
        {
            _gCost = gCost;
            _hCost = hCost;
            _fCost = _gCost + _hCost;
        }

        private void OnMouseEnter()
        {
            _highlight.SetActive(true);
        }

        private void OnMouseExit()
        {
            _highlight.SetActive(false);
        }
    }
}
