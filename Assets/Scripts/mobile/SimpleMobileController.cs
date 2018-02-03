using UnityEngine;

public class SimpleMobileController : MonoBehaviour {

    private static SimpleMobileController instance;

    public float actionTime = 0.2f;

    public Vector2 touchPos1 = Vector2.zero;

    // Helps to detect action
    private float startTime = -1f;

    private Stats stats = new Stats();

    public float precisionFix = 8f;
    private float calcFix = 0.005f;  // 1280
    private float horizontal = 0f;
    private float vertical = 0f;


    public static SimpleMobileController GetInstance() {
        return instance;
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }


    void Start() {

    }

    void Update() {

        calcFix = precisionFix / (Screen.width > Screen.height? Screen.width : Screen.height);

        if (Input.touchCount > 0 && Input.touches[0].fingerId == 0) {
            Touch pri = Input.touches[0];

            if (pri.phase == TouchPhase.Began) {
                touchPos1 = pri.position;
            } else if (pri.phase == TouchPhase.Ended) {
                touchPos1 = Vector2.zero;
                stats.movement = Vector2.zero;
            } else if (pri.phase == TouchPhase.Moved || pri.phase == TouchPhase.Stationary) {
                stats.movement = pri.position - touchPos1;
            }

            checkForAction(pri);
        }

        if (Input.touchCount > 1 && Input.touches[1].fingerId == 1) {
            Touch t = Input.touches[1];
            if (t.phase == TouchPhase.Began && !stats.action2 ) {
                stats.action2 = true;
            } else if (t.phase == TouchPhase.Ended && stats.action2) {
                stats.action2 = false;
            }
            checkForAction(t);
        }

        this.horizontal = stats.movement.x * this.calcFix;
        this.vertical = stats.movement.y * this.calcFix;

        this.horizontal = Mathf.Min(Mathf.Abs(this.horizontal), 1) * (stats.movement.x > 0 ? 1: -1);
        this.vertical = Mathf.Min(Mathf.Abs(this.vertical), 1) * (stats.movement.y > 0 ? 1: -1);
    }

    private void checkForAction(Touch t) {
        if (t.phase == TouchPhase.Began) {
            startTime = Time.time;
        } else if (t.phase == TouchPhase.Ended) {
            if ((Time.time - startTime) < actionTime) {
                stats.action1 = true;
            }
        }
    }


    public float getHorizontal() {
        return horizontal;
    }

    public float getVertical() {
        return vertical;
    }

    public bool getAction1() {
        return stats.uniqueAction1();
    }

    public bool getAction2() {
        return stats.isAction2();
    }

    protected class Stats {

        public Vector2 movement = Vector2.zero;
        public bool action1 = false;
        public bool action2 = false;

        public bool uniqueAction1() {
            if (action1 ) {
                action1 = false;
                return true;
            }

            return action1;
        }

        public bool isAction1() {
            return action1;
        }

        public bool uniqueAction2() {
            if (action2 ) {
                action2 = false;
                return true;
            }

            return action2;
        }

        public bool isAction2() {
            return action2;
        }
    }
}