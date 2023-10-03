using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using TMPro;

namespace Line98
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private int _width = 3;
        [SerializeField] private int _height = 3;
        [SerializeField] private GameObject _tileGameObject;
        [SerializeField] private Tile _tileView;

        private int startX = 0;
        private int startY = 0;
        private int endX = 0;
        private int endY = 0;

        void Start()
        {
            float tileSize = _tileGameObject.GetComponent<SpriteRenderer>().size.x;

            _camera.transform.position =
                new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10f);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Start: " + startX + " " + startY);
            }

            if (Input.GetMouseButtonDown(1))
            {
                if(startX >= 0 && startY >= 0)
                {
                    Debug.Log("End: " + endX + " " + endY);
                }
                else
                {
                    Debug.Log("You must set Start Tile before end tile");
                }    
            }
        }

        private Vector3 GetMousePosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
