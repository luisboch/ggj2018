using UnityEngine;

[RequireComponent(typeof(CameraFollowGO))]
public class GameOverCameraControl : MonoBehaviour {
    public bool showDeadEffect;
    public Transform deadCameraPos;
    public float slowDownPhysics = 0.05f;

    private CameraFollowGO camera;
    private float effectTime = 2f;
    private AudioSource audioSource;
    private bool soundPlayed = false;

    void Start() {
        camera = GetComponent<CameraFollowGO>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (showDeadEffect) {
            camera.target = deadCameraPos;
            effectTime -= Time.deltaTime;

            Time.timeScale = Mathf.Max(Time.timeScale - slowDownPhysics, 0);

            if (Time.timeScale < 0.2) {
                Time.timeScale = 1;

                if (!soundPlayed) {
                    soundPlayed = true;
                    audioSource.Play();
                }

                showDeadEffect = false; // Don't execute more than once.
                Initiate.Fade("Gameover", Color.black, 2f);
            }


        }

    }
}
