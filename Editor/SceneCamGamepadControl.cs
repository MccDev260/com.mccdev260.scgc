using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

[InitializeOnLoad()]
public class SceneCamGamepadControl : Editor
{
    public static SCGC_Settings settings;

    static SceneCamGamepadControl()
    {
        EditorApplication.update += Update;
    }

    public static Vector3 pos;
    public static Quaternion rot;

    static void Update()
    {
        if (settings != null)
        {
            var gamepad = Gamepad.current;
            var keyboard = Keyboard.current;

            if (gamepad == null) return;

            SceneView view = SceneView.lastActiveSceneView;
            pos = view.pivot;
            rot = view.rotation;

            // Controls.
            Vector2 inputMove = gamepad.leftStick.ReadValue();
            Vector2 inputRotate = gamepad.rightStick.ReadValue();
            bool inputUp = gamepad.rightShoulder.isPressed;
            bool inputDown = gamepad.leftShoulder.isPressed;
            bool inputSelect = gamepad.aButton.isPressed;
            bool inputfocus = gamepad.bButton.isPressed;

            GameObject camTarget = new GameObject("SceneViewCamTarget");
            camTarget.transform.position = pos;
            camTarget.transform.rotation = rot;

            // Obj Selection.
            if (inputSelect)
            {
                if (Physics.Raycast(camTarget.transform.position, camTarget.transform.forward, out RaycastHit hit, settings.raycastDistance))
                {
                    if (hit.transform.gameObject)
                    {
                        Selection.activeGameObject = hit.transform.gameObject;
                    }
                }
            }

            // Focus.
            if (Selection.activeGameObject != null)
            {
                if (keyboard.fKey.isPressed || inputfocus)
                {
                    var activeObjPos = Selection.activeGameObject.transform.position;
                    camTarget.transform.position = activeObjPos + settings.focusOffset;
                    camTarget.transform.LookAt(activeObjPos);
                }
            }

            camTarget.transform.position += camTarget.transform.forward * inputMove.y * settings.lateralSpeed * Time.deltaTime;
            camTarget.transform.position += camTarget.transform.right * inputMove.x * settings.lateralSpeed * Time.deltaTime;
            camTarget.transform.position += inputUp ? camTarget.transform.up * settings.upSpeed * Time.deltaTime : camTarget.transform.up * 0f;
            camTarget.transform.position -= inputDown ? camTarget.transform.up * settings.downSpeed * Time.deltaTime : camTarget.transform.up * 0f;

            camTarget.transform.Rotate(Vector3.up, inputRotate.x * settings.rotationSpeed * Time.deltaTime);
            camTarget.transform.Rotate(Vector3.right, -inputRotate.y * settings.rotationSpeed * Time.deltaTime);
            camTarget.transform.rotation = Quaternion.Euler(camTarget.transform.eulerAngles.x,
                camTarget.transform.eulerAngles.y, 0f);

            pos = camTarget.transform.position;
            rot = camTarget.transform.rotation;

            view.pivot = pos;
            view.rotation = rot;
            view.size = 0f;

            GameObject.DestroyImmediate(camTarget);
        }
    }
}
