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
        [SerializeField] private Tile _cell;
        [SerializeField] private Camera _camera;

        private GridMap _grid;

        void Start()
        {
            _grid = GetComponent<GridMap>();

            _grid.CreateGrid(_cell);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = GetMousePosition();
                _grid.SetColorValue(mousePos, Color.yellow);
            }
        }

        private Vector3 GetMousePosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }    
    }
}
