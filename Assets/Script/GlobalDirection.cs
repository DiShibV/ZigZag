using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Forward, Left, All = Forward | Left
}
public static class GlobalDirection
{
    private static readonly Vector3[] VECTOR = new Vector3[]{ Vector3.forward, Vector3.left };

    public static Direction GetInverse(Direction direction){
        return ~Direction.All ^ ~direction;
    }

    public static Vector3 GetVector(Direction direction){
        return VECTOR[(int)direction];
    }

    public static Vector3 GetVectorInverse(ref Direction direction){
        direction = GetInverse(direction);
        return GetVector(direction);
    }

    public static float GetAmountDirections() =>
        VECTOR.Length;
}
