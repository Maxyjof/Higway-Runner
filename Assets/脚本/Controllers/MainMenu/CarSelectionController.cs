using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class CarSelectionController : MonoBehaviour
{
    public Camera Cam;
    public Ease CamMoveEase;
    public GameObject GetInMapButton;

    public List<Transform> Cars;
    public List<Transform> CarInfos;
    private int _CurrentCarIndex;

    public void StartToSelect()
    {
        ShowGetInMapButton();
        
        Cam.transform.DOMove(Cars[_CurrentCarIndex].position, 0.5f).SetEase(CamMoveEase);

        ShowCurrentCarInfo();
    }

    private void ShowCurrentCarInfo()
    {
        CarInfos.ForEach(x => x.gameObject.SetActive(false));
        CarInfos[_CurrentCarIndex].gameObject.SetActive(true);
    }

    private void ShowGetInMapButton()
    {
        GetInMapButton.SetActive(true);
    }
}