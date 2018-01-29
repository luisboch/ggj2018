using UnityEngine;

public class MobileController : MonoBehaviour {
    private float horizontal;
    private float vertical;
    private bool action;
    private bool running;
    public float multiplier;
    public float actionTime = 0.2f;
    private Vector2 touchOrigin = Vector2.zero;

    // Helps to detect action
    private float startTime = -1f;

    private Touch movementTouch = new Touch();
    private Touch runningTouch = new Touch();

    void Start() {
        movementTouch.phase = TouchPhase.Ended;
        runningTouch.phase = TouchPhase.Ended;
    }

    void Update() {

        running = false;
        action = false;

        horizontal = 0;
        vertical = 0;

        Debug.Log("TC:" + Input.touchCount);

        if (Input.touchCount > 0) {

            Touch primary = Input.touches[0];
            Touch sec;

            if (primary.phase == TouchPhase.Began) {
                startTime = Time.time;
                movementTouch = primary;
                touchOrigin = primary.position;
            }

            // Check fo second input.
            if (Input.touchCount > 1) {
                sec = Input.touches[1];
                if (sec.phase == TouchPhase.Began) {
                    runningTouch = sec;
                }
            }

            if (runningTouch.phase == TouchPhase.Ended || runningTouch.phase == TouchPhase.Canceled) {
                running = false;
            } else {
                running = true;
            }

            if ( movementTouch.phase == TouchPhase.Ended || movementTouch.phase == TouchPhase.Canceled) {
                touchOrigin = -Vector2.zero;
                if ((Time.time - startTime) < actionTime ) {
                    action = true;
                }
            } else if ( movementTouch.phase == TouchPhase.Moved) {
                // GEt de dif
                Vector2 result = (movementTouch.position - touchOrigin) * multiplier;

                result.Normalize();

                horizontal = result.x;
                vertical = result.y;
            }
        }

    }

    public bool isAction() {
        if (action) {
            action = false;
            return true;
        }
        return false;
    }

    public bool isRunning() {
        return running;
    }

    public float getHorizontal() {
        return horizontal;
    }

    public float getVertical() {
        return vertical;
    }
}