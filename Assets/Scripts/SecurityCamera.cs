using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour {
    //Rotation Sensitivity
    public float RotationSensitivity = 35.0f;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;

    //Rotation Value
    float yRotate = 0.0f;
    public float alertRadious = 3f;

    private Vector3 _startAngle;
    private Config _config;

    private LineOfSight lineOfSight;

    private void Start() {
        lineOfSight = GetComponentInChildren<LineOfSight>();
        _startAngle = transform.eulerAngles;
        _config = Config.getInstance();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, alertRadious);
    }
    // Update is called once per frame
    void Update() {

        //Rotate Y view
        yRotate += RotationSensitivity * Time.deltaTime;
        yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);

        if (yRotate == 45 || yRotate == -45)
        {
            RotationSensitivity *= -1;
        }

        transform.eulerAngles = (new Vector3(0.0f, yRotate, 0.0f)) + _startAngle;
    }

    void FixedUpdate() {
        lineOfSight.enabled = _config.lightIsOn;
        lineOfSight.SetStatus(LineOfSight.Status.Idle);

        if (lineOfSight.enabled) {
            if (lineOfSight.SeeByTag("Player")) {
                List<GameObject> obs = lineOfSight.getViewing();
                GameObject obj = obs[0];
                Player player = obj.GetComponent<Player>();

                if (player != null && !player.disguised) {

                    Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, alertRadious);

                    GameObject nearest = null;
                    float nearestDist = 0f;

                    foreach (Collider c in colliders) {
                        if (c.tag.Equals("Soldier")) {
                            float dist = Vector3.Distance(c.gameObject.transform.position, transform.position);
                            if (nearest == null || dist < nearestDist ) {
                                nearestDist = dist;
                                nearest = c.gameObject;
                            }
                        }
                    }

                    if (nearest != null) {

                        FSMManager g = nearest.GetComponent<FSMManager>();
                        BasicObjectAttr attr = nearest.GetComponent<BasicObjectAttr>();
                        // We arrive to destination
                        List<SearchConfig> searchConf = g.GetBasicState().GetSearchConfig();
                        foreach (SearchConfig sc in searchConf){
                            if(sc.doWhenAlert != null){
                                IAState st = sc.doWhenAlert.Invoke(obj);
                                g.setCurrentState(st);

                            }
                        }
                    }
                }

                lineOfSight.SetStatus(LineOfSight.Status.Alerted);

            }
        }
    }
}
