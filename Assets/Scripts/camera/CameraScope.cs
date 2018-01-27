using UnityEngine;

public class CameraScope : MonoBehaviour {


    /// <summary>
    /// Managed via script
    /// </summary>
    [HideInInspector]
    public float scope;
    public float changeVel = 3f;
    private Camera camera;

    void Start() {
        this.scope = scope;
        this.camera = GetComponent<Camera>();
    }

    void Update() {
        if (this.scope != this.camera.fieldOfView) {
            float dif = Mathf.Abs(this.scope + changeVel - camera.fieldOfView);
            float changeScope = changeVel;
            if (dif < this.scope) {
                changeScope = dif;
            }

            changeScope *= Time.deltaTime;

            if (camera.fieldOfView < this.scope) {
                camera.fieldOfView += changeScope;
            } else {
                camera.fieldOfView -= changeScope;
            }

        }
    }


}