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

        private PathFinding _pathFinding;

        void Start()
        {
            float tileSize = _tileGameObject.GetComponent<SpriteRenderer>().size.x;
            GameObject innerObject = _tileGameObject.transform.Find("Inner").gameObject;
            GameObject textContainer = innerObject.transform.Find("CostContainer").gameObject;
            TextMeshPro gCostTMP = textContainer.transform.Find("GCost").gameObject.GetComponent<TextMeshPro>();
            TextMeshPro hCostTMP = textContainer.transform.Find("HCost").gameObject.GetComponent<TextMeshPro>();
            TextMeshPro fCostTMP = textContainer.transform.Find("FCost").gameObject.GetComponent<TextMeshPro>();

            _pathFinding = new PathFinding(_width, _height, tileSize, _tileGameObject, innerObject, textContainer, gCostTMP, hCostTMP, fCostTMP);

            _camera.transform.position =
                new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10f);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
            }
        }

        private Vector3 GetMousePosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
