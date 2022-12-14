using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float OrthographicSize = 2f;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            
        {
            _camera.orthographicSize += Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * OrthographicSize;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _camera.orthographicSize -= Time.deltaTime * OrthographicSize;
        }
    }
}
