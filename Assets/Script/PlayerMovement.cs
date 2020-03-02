using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.2f,10)] private float _speed;
    private Rigidbody _player;
    private bool _isForwardDirection, _isStart;
    private Vector3 _directionMove;

    private void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //TODO: заняться рефакторингом кода
        if(Input.GetMouseButtonDown(0)){
            _isStart = true;
            _isForwardDirection = !_isForwardDirection;
            _directionMove = _isForwardDirection ? Vector3.forward : Vector3.left;
        }
        if(_isStart) transform.Translate(_directionMove * Time.deltaTime * _speed,Space.Self);
    }
}
