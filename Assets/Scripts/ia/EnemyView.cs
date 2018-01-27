using UnityEngine;

public class EnemyView : MonoBehaviour {

    public float alertDistPercent = 0.5f;

    // STEP 1: Access to line of sight
    private LineOfSight _lineOfSight;
    private Config _config;

    void Start() {
        _lineOfSight = GetComponentInChildren<LineOfSight>();
        _config = Config.getInstance();
    }

    void Update() {

        if (_lineOfSight.SeeByTag("Player")) {
            foreach (GameObject ob in _lineOfSight.getViewing()) {
                float dist = Vector3.Distance(ob.transform.position, transform.position);
                Player p = ob.GetComponent<Player>();
                float percent = dist / _lineOfSight.GetMaxDist();

                bool alerted = percent < alertDistPercent;
                if (alerted || _config.alert) {
                    _lineOfSight.SetStatus(LineOfSight.Status.Alerted);
                } else {
                    if (p && p.disguised) {
                        _lineOfSight.SetStatus(LineOfSight.Status.Suspicious);
                    } else {
                        _lineOfSight.SetStatus(LineOfSight.Status.Alerted);
                    }
                }


            }
        } else {
            _lineOfSight.SetStatus(LineOfSight.Status.Idle);
        }
    }
}