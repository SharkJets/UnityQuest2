﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SmoothTurning : MonoBehaviour
{
    private InputDevice device;
    private Vector2 inputStick;
    
    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    void Update()
    {
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputStick);

        if (inputStick.x > 0.2f || inputStick.x < -0.2f)
        {
            Turn();
        }
    }

    private void Turn()
    {
        var rotationAmount = transform.eulerAngles.y + inputStick.x;
        var directionVector = new Vector3(transform.eulerAngles.x, rotationAmount, transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(directionVector);
    }
}
