using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private int _countMaxBlock;
    [SerializeField] private GameObject _prefabBlock;
    private readonly Vector3[] _startPointsOfCreateBlock = new Vector3[]{new Vector3(0,0,2),new Vector3(-1,0,2),new Vector3(-2,0,1)};



}
