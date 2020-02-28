using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static Transform[] CreatedBlocks { get; private set; }
    private static readonly Vector3[] POINTS_NEXT_POSITION = new Vector3[]{Vector3.forward, Vector3.left};
    private readonly Vector3 START_POINT = new Vector3(-1,0,2);
    private static Vector3 _positionCreate;
    [SerializeField] private byte _countMaxBlock;
    [SerializeField] private GameObject _prefabBlock;
    private Transform _parentBlock;
    public float _TEST_engeCameraRight;

    private void Start()
    {
        TEST_EdgeCameraRight();
        CreateArrayBlocks();
    }

    [ContextMenu("EdgeCameraRight")]
    public void TEST_EdgeCameraRight(){
        _TEST_engeCameraRight = Camera.main.ViewportToWorldPoint (new Vector3(1,0.5f,0)).x;
    }

    public void RecreateBlocks(){
        Destroy(_parentBlock);
        _positionCreate = Vector3.zero;
        CreateArrayBlocks();
    }

    private void CreateArrayBlocks(){
        CreateParent();
        CreatedBlocks = new Transform[_countMaxBlock];
        CreatedBlocks[0] = CreateStartBlock();
        for (byte i = 1; i < _countMaxBlock; i++){
            CreatedBlocks[i] = CreateBlock( GetNextPosition() );
        }
    }

    private void CreateParent(){
        _parentBlock = new GameObject("ParentOfBlocks").transform;
        _parentBlock.SetParent(transform, false);
    }

    private Transform CreateStartBlock(){
        _positionCreate += START_POINT;
         return CreateBlock(START_POINT);
    }

    private Transform CreateBlock(Vector3 position){
        var block = Instantiate(_prefabBlock, _parentBlock).transform;
        block.localPosition = position;
        return block;
    }

    public Vector3 GetNextPosition(){
        var directionRandom = POINTS_NEXT_POSITION[ Random.Range(0, POINTS_NEXT_POSITION.Length) ];
        Debug.Log(transform.TransformVector(directionRandom));
        return _positionCreate += directionRandom;
    }

}
