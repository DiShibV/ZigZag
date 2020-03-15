using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEdge : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private const float DIAMETER_BLOCK = 1.41f;
    private static float _edgeHorizontal;

    private void Awake()
    {
        CalculateEdgeHorizontal();
    }

    private void CalculateEdgeHorizontal(){
        _edgeHorizontal = _camera.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x - DIAMETER_BLOCK;
    }

    public static bool CheckOverEdge(float horizontal){
        return horizontal > _edgeHorizontal;
    }
}
