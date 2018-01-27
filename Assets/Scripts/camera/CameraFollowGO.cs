using System;
using UnityEngine;

public class CameraFollowGO : MonoBehaviour {

    public Transform target;

    public float camSpeed = 5.0f;

    public bool followRotation = true;

    private Vector3 originalDifPos;


    void Start() {

        originalDifPos = target.position - transform.position;

        Config config = Config.getInstance();

        if (config.lockMouse) {
            Cursor.lockState = config.lockMouse ?  CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !config.lockMouse;
        }
    }

    void Awake() {
    }


    void LateUpdate() {

        if (followRotation) {
            //transform.position = target.position;
            var lerpPos = (target.position - transform.position) * Time.deltaTime * camSpeed;
            transform.position += lerpPos;
            transform.rotation = target.rotation;
        } else {
            Vector3 targetPos = target.position - originalDifPos;
            var lerpPos = (targetPos - transform.position) * Time.deltaTime * camSpeed;
            transform.position += lerpPos;
        }
    }
}
