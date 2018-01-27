using UnityEditor;
using UnityEngine;

public class Config : MonoBehaviour {

    private static Config instance = null;
    public bool lockMouse = true;
    public GameObject hero;
    public bool lightIsOn = true;
    public bool alert = false;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public static Config getInstance() {
        if (instance == null) {
            instance = new Config();
            Debug.LogWarning("No Config found, using default!");
        }
        return instance;
    }
}
