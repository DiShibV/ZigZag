using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockMovement))]
public class BlockSpawner : MonoBehaviour
{
    private List<Block> _createdBlocks = new List<Block>();
    [SerializeField] private byte _countMaxBlock;
    [SerializeField] private GameObject _prefabBlock;
    [SerializeField] private Block _blockStart;
    private Transform _parentBlock;
    private BlockMovement _blockMovement;

    private void Start()
    {
        _blockMovement = GetComponent<BlockMovement>();
        CreateArrayBlocks();
    }

    public void RetryBlocks(){
        _blockStart.ResetAnimator();
        _blockMovement.ApplyStartPosition(_createdBlocks[0]);
        for (byte i = 1; i < _countMaxBlock; i++)
            _blockMovement.ApplyNextPosition(_createdBlocks[i]);
    }

    private void CreateArrayBlocks(){
        CreateParent();
        _createdBlocks.Add(CreateStartBlock());
        for (byte i = 1; i < _countMaxBlock; i++)
            _createdBlocks.Add(CreateNextBlock());
    }

    private void CreateParent(){
        _parentBlock = new GameObject("ParentOfBlocks").transform;
        _parentBlock.SetParent(transform, false);
    }

    private Block CreateStartBlock(){
        var block = CreateBlock();
        _blockMovement.ApplyStartPosition(block);
        return block;
    }

    private Block CreateNextBlock(){
        var block = CreateBlock();
        _blockMovement.ApplyNextPosition(block);
        return block;
    }

    private Block CreateBlock(){
        return Instantiate(_prefabBlock, _parentBlock).GetComponent<Block>();
    }

    public void MoveFirstElementBlockToEnd(){
        var tmp = _createdBlocks[0];
        _createdBlocks.RemoveAt(0);
        _createdBlocks.Add(tmp);
    }

    public Block GetLastElementBlock(){
        return _createdBlocks[_countMaxBlock - 1];
    }
}
