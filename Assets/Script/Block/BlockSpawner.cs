using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private List<Block> _createdBlocks = new List<Block>();
    [SerializeField] private byte _countMaxBlock;
    [SerializeField] private GameObject _prefabBlock;
    [SerializeField] private Block _blockStart;
    [SerializeField] private Transform _parentOfBlocks;
    [SerializeField] private BlockMovement _blockMovement;

    private void Start()
    {
        CreateArrayBlocks();
    }

    public void RetryBlocks(){
        _blockStart.ResetAnimator();
        _blockMovement.ApplyStartPosition(_createdBlocks[0]);
        for (byte i = 1; i < _countMaxBlock; i++)
            _blockMovement.ApplyNextPosition(_createdBlocks[i]);
    }

    private void CreateArrayBlocks(){
        _createdBlocks.Add(CreateStartBlock());
        for (byte i = 1; i < _countMaxBlock; i++)
            _createdBlocks.Add(CreateNextBlock());
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
        return Instantiate(_prefabBlock, _parentOfBlocks).GetComponent<Block>();
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
