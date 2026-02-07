using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Datas
{
    [CreateAssetMenu(fileName = "Car Info Data List", menuName = "Game/Car Info Data List")]
    public class CarInfoDataList : ScriptableObject
    {
        public List<CarInfoData> DataList;
    }

    [Serializable]
    public class CarInfoData
    {
        public string Name;
        public float Speed;
        public float AccelerationTime;
        public float TurningSpeed;
        public string Handing;
        public int Gear;
    }
}