using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MccDev260.Tools
{
    [CreateAssetMenu(fileName = "SCGC_Settings", menuName = "MccDev260/EditorTools/SCGC_Setings", order = 0)]
    public class SCGC_Settings : ScriptableObject
    {
        public Vector3 focusOffset = new Vector3(0f, 0f, -5f);
        public float lateralSpeed = 15f;
        public float rotationSpeed = 40f;
        public float upSpeed = 1f;
        public float downSpeed = 1f;
        public float raycastDistance = 100f;

        private void OnValidate()
        {
            SceneCamGamepadControl.settings = this;
        }
    }
}
