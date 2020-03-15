using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeparture : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _direction;

    public void DepartureOut(Direction direction){
        setDirection(direction);
        PlayAnimation();
    }

    private void setDirection(Direction direction){
        _direction.localRotation = Quaternion.LookRotation(GlobalDirection.GetVector(direction));
    }

    private void PlayAnimation(){
        _animator.enabled = true;
    }

    public void ResetAnimation(){
        _animator.Rebind();
        _animator.enabled = false;
    }


}