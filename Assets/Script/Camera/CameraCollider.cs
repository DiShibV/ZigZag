using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.GetComponent<ICameraOnTrigger>();
        if(trigger != null){
            trigger.OnTrigger();
        }
    }
}
