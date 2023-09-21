using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Line98
{
    interface ITile
    {
        GameObject Inner { get; set; }
    }

    public class Tile: MonoBehaviour, ITile
    {
        [SerializeField] private GameObject _inner;
        public GameObject Inner 
        { 
            get { return _inner; }
            set { _inner = value; }
        }

        public void SetColour(Color colour)
        {
            _inner.GetComponent<SpriteRenderer>().material.color = colour;
        }    
    }
}
