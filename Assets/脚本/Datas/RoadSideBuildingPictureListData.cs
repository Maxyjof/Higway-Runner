using System.Collections.Generic;
using UnityEngine;

namespace Game.Datas
{
    [CreateAssetMenu(fileName = "Road Side Object Picture List", menuName = "Game/Road Side Object Picture List")]
    public class RoadSideObjectPictureListData : ScriptableObject
    {
        public List<Sprite> PictureList;
    }
}