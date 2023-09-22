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
        [SerializeField] private Camera _camera;
        [SerializeField] private int _width = 3;
        [SerializeField] private int _height = 3;

        private GridMap _grid;

        void Start()
        {
            _grid = GetComponent<GridMap>();
            _grid.CreateGrid(_width, _height);

            _camera.transform.position =
                new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10f);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                _grid.SetValue(GetMousePosition(), 10, 28);
            }
        }

        private Vector3 GetMousePosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }    
    }
}
