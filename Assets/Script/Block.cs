using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, ICameraOnTrigger
{
    [SerializeField] private GameObject[] LeftAndForward;
    private Animator _animatorBlock;

    private void Start() {
        _animatorBlock = GetComponent<Animator>();
    }

    public void ApplyActiveTriggers(Direction direction){
        LeftAndForward[0].SetActive(false);
        LeftAndForward[1].SetActive(false);
        LeftAndForward[(int)direction].SetActive(true);
    }

    public void ResetAnimator() {
        _animatorBlock.enabled = false;
        _animatorBlock.Rebind();
    }

    public void OnTrigger() {
         _animatorBlock.enabled = true;
    }
}
