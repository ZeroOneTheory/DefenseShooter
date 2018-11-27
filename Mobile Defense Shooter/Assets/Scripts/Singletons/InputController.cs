using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController: MonoBehaviour{

    public bool fireKey;
    public bool isDragging;
    public Vector2 touchStart;
    public Vector2 touchPosition;
    public Vector2 swipeDelta;


    private void Update() {


        fireKey = Input.GetKeyDown(KeyCode.Space);

        if (Input.touchCount > 0) {
            touchPosition = Input.touches[0].position;
            if (Input.touches[0].phase == TouchPhase.Began) {       
                touchStart = Input.touches[0].position;
                isDragging = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                ResetTouches();
            }
            
        }

        swipeDelta = Vector2.zero;
        if (isDragging) {
            swipeDelta = Input.touches[0].position - touchStart;
        }
    }

    public void ResetTouches() {
        touchStart = swipeDelta = touchPosition = Vector2.zero;
        isDragging = false;
    }

}
