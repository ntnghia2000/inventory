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
        int FCost { get; set; }
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
            set { _gCost = value; }
        }

        public int HCost
        {
            get => _hCost;
            set { _hCost = value; }
        }

        public int FCost
        {
            get => _fCost;
            set { _fCost = value; }
        }

        public void SetActiveTMP(bool isActive)
        {
            _costContainer.SetActive(isActive);
        }

        public void SetTileColor(Color color)
        {
            _innerSR.color = color;
        }
        
        public void SetGCost(int cost)
        {
            _gCost = cost;
            _gCostTMP.text = _gCost.ToString();
        }

        public void SetHCost(int cost)
        {
            _hCost = cost;
            _hCostTMP.text = _hCost.ToString();
        }

        public void SetFCost(int cost)
        {
            _fCost = _gCost + _hCost;
            _fCostTMP.text = _fCost.ToString();
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
