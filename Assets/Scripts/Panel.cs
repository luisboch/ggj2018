using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Panel : MonoBehaviour {

    public bool key_panel = true;
    Config config = new Config();

	// Use this for initialization
	void Start () {
		
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
