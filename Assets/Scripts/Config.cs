using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Config : MonoBehaviour {

    private static Config instance = null;
    public bool lockMouse = true;
    public GameObject hero;
    public bool lightIsOn = true;
    public bool _alert = false;
    public List<GameObject> infos = new List<GameObject>();
    public int collectedInfos;
    public int infosCountScene;

    public bool alert {
        get {
            return _alert;
        }
        set {
            _alert = value;
            remainingAlertTime = alertTime;
        }
    }

    public float alertTime = 15f;
    private float remainingAlertTime;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        collectedInfos = 0;
        infosCountScene = 0;
    }

    // Update is called once per frame
    void Update() {

        if (remainingAlertTime > 0) {
            remainingAlertTime -= Time.deltaTime;
        } else if (this._alert) {
            this._alert = false;
            remainingAlertTime = -1;
        }
    }

    public static Config getInstance() {
        if (instance == null) {
            instance = new Config();
            Debug.LogWarning("No Config found, using default!");
        }
        return instance;
    }

    public void LoadInfosScene()
    {
        infos.Clear();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Info");
        foreach(GameObject o in objs)
        {
            infos.Add(o);
        }
        infosCountScene = infos.Count;
    }

    public void UpdateCollectedInfos()
    {
        collectedInfos++;
    }

}
