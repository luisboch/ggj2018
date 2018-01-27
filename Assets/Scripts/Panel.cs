using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Panel : MonoBehaviour {

    public bool key_panel = true;
    Config config;
    private Fog fog = new Fog();

    // Use this for initialization
    void OnCollisionEnter(Collision colisor)
    {
        if ((colisor.gameObject.tag == "Player"))
        {
            key_panel = false;
            // Destroy(gameObject);



        }
    }
    void Start () {
        config = Config.getInstance();
	}
	
	// Update is called once per frame
	void Update () {
        if(key_panel == true)
        {
            config.lightIsOn = true;
        }
        else if (key_panel == false)
        {
            config.lightIsOn = false;

          
        }
		
	}
   
}
