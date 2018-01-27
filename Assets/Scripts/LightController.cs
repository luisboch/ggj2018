using UnityEngine;

public class LightController : MonoBehaviour {
    private Light light;

    public float offVal = 0.2f;
    public float onVal = 0.6f;
    public float changeVal = 0.01f;
    public bool autoOn = true;
    public float autoOnTime = 15f;
    private float remaningOffTime = 0f;

    private Config _config;

    void Start() {
        _config = Config.getInstance();
        this.light = GetComponent<Light>();

    }

    void FixedUpdate() {
        float target = _config.lightIsOn ? onVal :offVal;

        if (Mathf.Abs(light.intensity - target) > changeVal) {
            if (light.intensity > target) {
                light.intensity -= changeVal;
            } else {
                light.intensity += changeVal;
            }
        }

        if (!_config.lightIsOn && autoOn) {
            remaningOffTime -= Time.deltaTime;
            if(remaningOffTime < 0){
                remaningOffTime = this.autoOnTime;
                _config.lightIsOn = true;
            }
        }

    }
}
