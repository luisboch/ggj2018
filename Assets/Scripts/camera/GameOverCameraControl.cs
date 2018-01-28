using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CameraFollowGO))]
public class GameOverCameraControl : MonoBehaviour {
    public bool showDeadEffect;
    public Transform deadCameraPos;
    public float slowDownPhysics = 0.05f;

    private CameraFollowGO camera;
    private float effectTime = 2f;

    void Start() {
        camera = GetComponent<CameraFollowGO>();
    }

    void Update() {
        if (showDeadEffect) {
            camera.target = deadCameraPos;
            effectTime -= Time.deltaTime;

            Time.timeScale = Mathf.Max(Time.timeScale - slowDownPhysics, 0);

            if (Time.timeScale < 0.2) {
                Time.timeScale = 1;
                showDeadEffect= false; // Don't execute more than once.
                Initiate.Fade("Gameover", Color.black, 2f);
            }
        }

    }
}
