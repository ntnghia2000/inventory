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
    }

    public class TileData: ITile
    {
        private int _gCost = 0;
        private int _hCost = 0;
        private int _fCost = 0;
        private bool _isPassable = false;
        private int _col = 0;
        private int _row = 0;

        public TileData() 
        {
            _gCost = _hCost = _fCost = 0;
            _isPassable = false;
            _col = _row = 0;
        }

        public TileData(int row, int col)
        {
            _gCost = _hCost = _fCost = 0;
            _isPassable = false;
            _row = row;
            _col = col;
        }

        public bool IsPassable
        {
            get { return _isPassable; }
            set { _isPassable = value; }
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
    }
}
