using UnityEngine;

public class CameraSnap : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _centerForCamera;
    private static CameraSnap instance;

    private void Start()
    {
        instance = this;
        _centerForCamera = transform;
    }

    private void Update()
    {
        ApplyPositionCamera();
    }

    private void ApplyPositionCamera(){
        if(GameManager.isStart)
            _centerForCamera.position = Vector3.forward * _target.position.z;
    }

    public static void Retry(){
        instance.transform.position = Vector3.zero;
    }

}
