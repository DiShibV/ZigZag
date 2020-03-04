using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BlockSpawner))]
public class BlockMovement : MonoBehaviour
{
    private readonly Vector3 START_POINT = new Vector3(-1,0,2);
    [SerializeField] private Transform _pointForCheckOutsideLastBlock;
    private Block _lastBlock;
    private Vector3 _lastLocalPosition => _lastBlock.transform.localPosition;
    private BlockSpawner _blockSpawner;

    private void Start()
    {
        _blockSpawner = GetComponent<BlockSpawner>();
    }

    private void Update(){
        ChangeParametersBlock();
    }

    private void ChangeParametersBlock(){
        if(!CheckOutsideLastBlock()) return;
        _blockSpawner.MoveFirstElementBlockToEnd();
        ApplyNextPosition(_blockSpawner.GetLastElementBlock());
        _lastBlock.ResetAnimator();
    }

    private bool CheckOutsideLastBlock(){
        return _pointForCheckOutsideLastBlock.position.z > _lastBlock.transform.position.z;
    }

    public void ApplyStartPosition(Block block){
        block.transform.localPosition = START_POINT;
        _lastBlock = block;
    }

    public void ApplyNextPosition(Block block){
        var direction = RandomDirection();
        block.transform.localPosition = GetNextPosition(ref direction);
        _lastBlock.ApplyActiveTriggers(direction);
        _lastBlock = block;
    }

    private Direction RandomDirection(){
        return  (Direction)Random.Range(0, GlobalDirection.GetAmountDirections());
    }

    private Vector3 GetNextPosition(ref Direction direction){
        var nextPosition = GlobalDirection.GetVector(direction) + _lastLocalPosition;
        nextPosition = TryGetChangeDirection(nextPosition, ref direction);
        return nextPosition ;
    }

    private Vector3 TryGetChangeDirection(Vector3 nextPosition, ref Direction direction){
        if(ViewEdge.CheckOverEdge( LocalToWorldSpaceX(nextPosition) ))
            nextPosition = GlobalDirection.GetVectorInverse(ref direction) + _lastLocalPosition;
        return nextPosition;
    }

    private float LocalToWorldSpaceX(Vector3 nextPosition){
        return Mathf.Abs(transform.TransformPoint(nextPosition).x);
    }
}
