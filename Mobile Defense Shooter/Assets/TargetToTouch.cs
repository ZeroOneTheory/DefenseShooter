using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetToTouch : MonoBehaviour {

    public InputController input;
    public LayerMask Ground;
    public Camera cam;

    private void Start() {
        input = GameManager.Instance.InputController;
    }
    private void Update() {
        Ray ray = cam.ScreenPointToRay(input.touchPosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100f, Ground))
            transform.position = hitInfo.point;
    }
}
