using UnityEngine;

public class CameraSnap : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _centerForCamera;

    private void Start()
    {
        _centerForCamera = transform;
    }

    private void LateUpdate()
    {
        ApplyPositionCamera();
    }

    private void ApplyPositionCamera(){
        _centerForCamera.position = Vector3.forward * _target.position.z;
    }

    public void Disable(){
        enabled = false;
    }

    public void Enable(){
        enabled = true;
    }

    public void Retry(){
        transform.position = Vector3.zero;
    }

}
