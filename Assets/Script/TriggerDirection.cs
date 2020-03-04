using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDirection : MonoBehaviour, IPlayerOnTrigger
{
    [SerializeField] private Direction _direction;

    public void OnTrigger()
    {
        GameManager.instance.GameOver(_direction);
    }
}