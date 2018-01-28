using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    private static Config instance = null;
    public bool lockMouse = true;
    public GameObject hero;
    public bool lightIsOn = true;
    private bool _alert = false;
    private List<GameObject> infos = new List<GameObject>();
    private static int collectedInfos;
    private static int infosCountScene;
    public static string nextScene;

    public bool alert {
        get {
            return _alert;
        }
        set {
            if(_alert != value && value){
                // Play Sound
                audioSource.Play();
            }
            _alert = value;
            remainingAlertTime = alertTime;

        }
    }

    public float alertTime = 15f;
    private float remainingAlertTime;
    private AudioSource audioSource;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        this.audioSource = GetComponent<AudioSource>();
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
            //Debug.LogWarning("No Config found, using default!");
        }
        else
        {
            //Debug.LogWarning("There is a Config already!!! Let's use it!");
        }
        return instance;
    }

    public void LoadInfosScene()
    {
        infosCountScene = 0;
        collectedInfos = 0;
        infos.Clear();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Info");
        foreach(GameObject o in objs)
        {
            infos.Add(o);
        }
        infosCountScene = infos.Count;
        //Debug.Log("Infos total:  "+infosCountScene);
    }

    public void UpdateCollectedInfos()
    {
        collectedInfos++;
        //Debug.Log("Collected:  " + collectedInfos);
    }

    public bool IsAllInfosCollected()
    {
        return infosCountScene > 0 && collectedInfos >= infosCountScene;
    }

    public void SetNextScene(string s)
    {
        nextScene = s;
    }

    public string GetNextScene()
    {
        return nextScene;
    }

}
