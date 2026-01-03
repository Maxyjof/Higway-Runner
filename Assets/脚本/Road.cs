using System;
using UnityEngine;

public class Road : MonoBehaviour
{
    public MeshRenderer RoadMeshRenderer;
    public Transform NextRoadPoint;

    [HideInInspector]
    public bool UsedAngle;
    
    public void SetMaterial(Material mat)
    {
        RoadMeshRenderer.material = mat;
    }
}
