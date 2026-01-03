using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("引用")]
    public Transform SceneRoot;

    [Header("属性")]
    public float TurningSpeed;

    private void Update()
    {
        var horizontalOffset = 0f;

        if (Input.GetKey(KeyCode.A)) horizontalOffset -= TurningSpeed;
        if (Input.GetKey(KeyCode.D)) horizontalOffset += TurningSpeed;

        SceneRoot.position -= Vector3.right * horizontalOffset * Time.deltaTime;
    }
}