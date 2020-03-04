using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var trigger = other.GetComponent<ICameraOnTrigger>();
        if(trigger != null){
            trigger.OnTrigger();
        }
    }
}
