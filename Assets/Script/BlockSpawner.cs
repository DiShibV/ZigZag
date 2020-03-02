using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockMovement))]
public class BlockSpawner : MonoBehaviour
{
    private List<Transform> _createdBlocks = new List<Transform>();
    [SerializeField] private byte _countMaxBlock;
    [SerializeField] private GameObject _prefabBlock;
    private Transform _parentBlock;
    private BlockMovement _blockMovement;

    private void Start()
    {
        _blockMovement = GetComponent<BlockMovement>();
        CreateArrayBlocks();
    }

    public void RestartBlocks(){
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

    private Transform CreateStartBlock(){
        var block = CreateBlock();
        _blockMovement.ApplyStartPosition(block);
        return block;
    }

    private Transform CreateNextBlock(){
        var block = CreateBlock();
        _blockMovement.ApplyNextPosition(block);
        return block;
    }

    private Transform CreateBlock(){
        return Instantiate(_prefabBlock, _parentBlock).transform;
    }

    public void MoveFirstElementBlockToEnd(){
        var tmp = _createdBlocks[0];
        _createdBlocks.RemoveAt(0);
        _createdBlocks.Add(tmp);
    }

    public Transform GetLastElementBlock(){
        return _createdBlocks[_countMaxBlock - 1];
    }
}
