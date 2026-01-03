using System.Collections.Generic;
using UnityEngine;

public class RoadMovementController : MonoBehaviour
{
    [Header("引用")]
    public Transform SceneRoot;
    public Transform VCFollowPoint;
    public Transform Cam;
    public List<Road> RoadPrefabs;
    public List<Material> RoadMaterials;

    [Header("属性")]
    public int RoadStyleIndex;
    public float Speed;
    public float MaxViewDistance;
    [Header("运行时属性")]
    public float DriveDistance;
    public int SameAngleCount;
    public int LastRoadTypeIndex;
    public List<Road> ActiveRoads;

    private void Start()
    {
        //动态创建初始道路
        var hasMaxViewRoad = false;
        while (!hasMaxViewRoad)
        {
            var newRoad = Instantiate(RoadPrefabs[0], SceneRoot);
            newRoad.SetMaterial(RoadMaterials[RoadStyleIndex]);
            if (ActiveRoads.Count > 0)
                newRoad.transform.localPosition = ActiveRoads[ActiveRoads.Count - 1].transform.localPosition + ActiveRoads[ActiveRoads.Count - 1].NextRoadPoint.transform.localPosition;
            ActiveRoads.Add(newRoad);

            if (ActiveRoads.Count >= MaxViewDistance) hasMaxViewRoad = true;
        }
    }

    private void Update()
    {
        if (Speed == 0) return;
        if (ActiveRoads.Count == 0) return;

        //行驶距离增加
        var moveOffset = Speed * Time.deltaTime;
        DriveDistance += moveOffset;

        //计算道路位移坐标
        // foreach (var road in ActiveRoads)
        // {
        //     road.transform.localPosition -= new Vector3(0, 0, moveOffset);
        // }

        var firstRoad = ActiveRoads[0];
        var secondRoad = ActiveRoads[1];

        //更新相机的位置和旋转
        var move = (secondRoad.transform.position - Cam.position).normalized * moveOffset;
        Cam.rotation = Quaternion.Lerp(Cam.rotation, secondRoad.transform.rotation, move.magnitude / (secondRoad.transform.position - firstRoad.transform.position).magnitude);
        Cam.position += move;

        //当有道路需要删除时，更新道路
        if ((Cam.position - secondRoad.transform.position).magnitude < 0.1f)
        {
            //var lastRoad = ActiveRoads[ActiveRoads.Count - 1];

            //更新地图的旋转
            if (!firstRoad.UsedAngle && firstRoad.NextRoadPoint.rotation != Quaternion.identity)
            {
                //所有道路自己旋转
                // if (firstRoad.NextRoadPoint.localEulerAngles.y != 0)
                // {
                //     foreach (var road in ActiveRoads)
                //     {
                //         road.transform.RotateAround(Vector3.zero, Vector3.up, -firstRoad.NextRoadPoint.localEulerAngles.y);
                //     }
                // }
                //
                // if (firstRoad.NextRoadPoint.localEulerAngles.x != 0)
                // {
                //     foreach (var road in ActiveRoads)
                //     {
                //         road.transform.RotateAround(Vector3.zero, Vector3.right, -firstRoad.NextRoadPoint.localEulerAngles.x);
                //     }
                //
                //     SceneRoot.position += Vector3.up * 0.1f * (firstRoad.NextRoadPoint.eulerAngles.x < 0 ? 1 : -1);
                // }

                //VC相机旋转
                // VCFollowPoint.position = firstRoad.NextRoadPoint.position;
                // VCFollowPoint.rotation = firstRoad.NextRoadPoint.rotation;
                // VCFollowPoint.position += VCFollowPoint.up * 0.5f;

                //相机跟随
                //VCFollowPoint.position = Vector3.Lerp(VCFollowPoint.position, secondRoad.transform.position, moveOffset);
                //VCFollowPoint.rotation = secondRoad.transform.rotation;

                firstRoad.UsedAngle = true;
            }

            //删除背后的道路
            ActiveRoads.Remove(firstRoad);
            Destroy(firstRoad.gameObject);

            //再生成一个新的道路到最前面去，这样总长度就是不变的
            //选择道路类型
            if (SameAngleCount < 5)
            {
                SameAngleCount++;
            }
            else
            {
                SameAngleCount = 0;

                LastRoadTypeIndex = Random.Range(0, RoadPrefabs.Count);
            }

            //生成道路
            var newRoad = Instantiate(RoadPrefabs[LastRoadTypeIndex], SceneRoot);
            newRoad.SetMaterial(RoadMaterials[RoadStyleIndex]);
            newRoad.transform.position = ActiveRoads[ActiveRoads.Count - 1].NextRoadPoint.transform.position;
            newRoad.transform.rotation = ActiveRoads[ActiveRoads.Count - 1].NextRoadPoint.rotation;

            ActiveRoads.Add(newRoad);
        }
    }
}