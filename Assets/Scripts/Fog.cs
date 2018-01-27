using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour {

    private List<GameObject> Players = new List<GameObject>();
    private Renderer renderer;
    public float Timer = 10;
    private float internalTimer;
    Config config;
	// Use this for initialization
	void Start () {
        renderer = this.gameObject.GetComponent<Renderer>();
        config = Config.getInstance();
    }

    // Update is called once per frame
    void Update () {
        internalTimer -= Time.deltaTime;

        if (config.lightIsOn == false)
        {
            turnLightsOff();
        }
        if (config.lightIsOn == true)
        {
            turnLightsOn();
        }
        
      /* else if (config.lightIsOn == false)
        {
            turnLightsOff();
        }}*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Players.Add(other.gameObject);
            turnLightsOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Players.Remove(other.gameObject);

            if (Players.Count == 0)
            {
                turnLightsOff();
            }
        }
    }


    void turnLightsOn()
    {
        renderer.enabled = false;
        internalTimer = Timer;
    }

    void turnLightsOff()
    {
        renderer.enabled = true;
    }
}
