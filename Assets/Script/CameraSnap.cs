using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSnap : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _centerForCamera;

    private void Start()
    {
        _centerForCamera = transform;
    }

    private void Update()
    {
        ApplyPositionCamera();
    }

    private void ApplyPositionCamera(){
        _centerForCamera.position = Vector3.forward * _target.position.z;
    }

}
