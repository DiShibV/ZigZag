using UnityEngine;

public class Block : MonoBehaviour, ICameraOnTrigger
{
    [SerializeField] private GameObject[] LeftAndForward;
    [SerializeField] private Crystal crystal;
    [SerializeField] private Animator _animator;

    public void ApplyActiveTriggers(Direction direction){
        LeftAndForward[0].SetActive(false);
        LeftAndForward[1].SetActive(false);
        LeftAndForward[(int)direction].SetActive(true);
    }

    public void Reset(){
        crystal.Show();
        ResetAnimator();
    }

    public void ResetAnimator() {
        _animator.enabled = false;
        _animator.Rebind();
    }

    public void OnTrigger() {
         _animator.enabled = true;
    }
}
