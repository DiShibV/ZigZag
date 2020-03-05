using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.2f,10)] private float _speed, _playerPushForceAfterLoss;
    private Rigidbody _player;
    private Direction _direction = Direction.Left;
    private Vector3 _directionMove;

    private void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
#if UNITY_ANDROID
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
#else
        if(Input.GetMouseButtonDown(0))
#endif
        {
            ChangeDirection();
            GameManager.StartGame();
        }
        Move();
    }

    private void ChangeDirection(){
        _directionMove = GlobalDirection.GetVectorInverse(ref _direction);
    }

    private void Move(){
        if(GameManager.isStart)
            transform.Translate(_directionMove * Time.deltaTime * _speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!GameManager.isStart) return;
        var trigger = other.GetComponent<IPlayerOnTrigger>();
        if(trigger != null){
            trigger.OnTrigger();
        }
    }

    public void Disable(){
        enabled = false;
    }

    public void Reset(){
        _direction = Direction.Left;
        _player.isKinematic = true;
        transform.localPosition = Vector3.zero;
        enabled = true;
    }

    public void AddForce(Direction direction){
        _player.isKinematic = false;
        _player.AddRelativeForce(GlobalDirection.GetVector(direction) * _playerPushForceAfterLoss, ForceMode.Impulse);
    }
}
