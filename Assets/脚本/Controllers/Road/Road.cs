using System;
using UnityEngine;

namespace Game.Controllers
{
    public class Road : MonoBehaviour
    {
        public MeshRenderer RoadMeshRenderer;
        public Transform NextRoadPoint;

        public RoadType Type;

        [HideInInspector]
        public bool UsedAngle;

        public void SetMaterial(Material mat)
        {
            RoadMeshRenderer.material = mat;
        }
    }

    public enum RoadType
    {
        Mid,
        Left,
        Right,
        Up,
        Down,
    }
}