using System;
using System.Collections.Generic;
using Game.Datas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Controllers
{
    public class RoadSideObject : MonoBehaviour
    {
        public RoadSideObjectPictureListData ObjectList;

        private SpriteRenderer _Renderer;

        private void Awake()
        {
            _Renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _Renderer.sprite = ObjectList.PictureList[Random.Range(0, ObjectList.PictureList.Count)];
        }
    }
}