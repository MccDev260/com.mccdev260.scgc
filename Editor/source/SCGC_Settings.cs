using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCGC_Settings : ScriptableObject
{   
    public Vector3 focusOffset = new Vector3(0f, 0f, -5f);
    public float lateralSpeed = 10f;
    public float rotationSpeed = 10f;
    public float upSpeed = 5f;
    public float downSpeed = 5f;
    public float raycastDistance = 100f;

    private void OnValidate()
    {
        SceneCamGamepadControl.settings = this;
    }
}
