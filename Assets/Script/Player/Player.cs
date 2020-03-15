using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.2f,10)] private float _speed;
    [SerializeField] private PlayerDeparture playerDeparture;
    private Direction _direction = global::Direction.Left;
    private Vector3 _directionMove;

    private void Update()
    {
#if UNITY_ANDROID
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
#else
        if(Input.GetMouseButtonDown(0))
#endif
        {
            ChangeDirection();
        }
        Move();
    }

    private void ChangeDirection(){
        _directionMove = GlobalDirection.GetVectorInverse(ref _direction);
    }

    private void Move(){
        Debug.Log("Move");
        transform.Translate(_directionMove * Time.deltaTime * _speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        var trigger = other.GetComponent<IPlayerOnTrigger>();
        if(trigger != null){
            trigger.OnTrigger();
        }
    }

    public void Disable(Direction direction){
        enabled = false;
        playerDeparture.DepartureOut(direction);
    }

    public void Enable(){
        enabled = true;
        InitializationDirection();
    }

    public void Retry(){
        transform.localPosition = Vector3.zero;
        playerDeparture.ResetAnimation();
    }

    private void InitializationDirection(){
        _direction = Direction.Forward;
        _directionMove = GlobalDirection.GetVector(_direction);
    }
}
