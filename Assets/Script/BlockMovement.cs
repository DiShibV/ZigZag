using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockSpawner))]
public class BlockMovement : MonoBehaviour
{
    private readonly Vector3[] POINTS_NEXT_POSITION = new Vector3[]{Vector3.forward, Vector3.left};
    private readonly Vector3 START_POINT = new Vector3(-1,0,2);
    [SerializeField] private Transform _pointForCheckOutsideLastBlock;
    private Vector3 _positionCreate;
    private BlockSpawner _blockSpawner;
    private float _lastBlockPositionZ;

    private void Start()
    {
        _blockSpawner = GetComponent<BlockSpawner>();
    }

    private void Update(){
        ChangePositionBlock();
    }

    private void ChangePositionBlock(){
        if(!CheckOutsideLastBlock()) return;
        _blockSpawner.MoveFirstElementBlockToEnd();
        ApplyNextPosition(_blockSpawner.GetLastElementBlock());
    }

    private bool CheckOutsideLastBlock(){
        return _pointForCheckOutsideLastBlock.position.z > _lastBlockPositionZ;
    }

    public void ApplyStartPosition(Transform block){
        block.localPosition = GetStartPosition();
    }

    private Vector3 GetStartPosition(){
        _positionCreate = START_POINT;
        return _positionCreate;
    }

    public void ApplyNextPosition(Transform block){
        block.localPosition = GetNextPosition();
        SetLastBlock(block.position.z);
    }

    private Vector3 GetNextPosition(){
        var randomIndex = Random.Range(0, POINTS_NEXT_POSITION.Length);
        var nextPos = _positionCreate + POINTS_NEXT_POSITION[randomIndex];
        if(ViewEdge.CheckOverEdge(Mathf.Abs(transform.TransformPoint(nextPos).x))){
            randomIndex = randomIndex == 0 ? 1 : 0;
            nextPos = _positionCreate + POINTS_NEXT_POSITION[randomIndex];
        }
        return _positionCreate = nextPos;
    }

    private void SetLastBlock(float positionZ){
        _lastBlockPositionZ = positionZ;
    }
}
