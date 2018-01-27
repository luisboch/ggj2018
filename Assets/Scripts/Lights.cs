using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {
    public bool light = true;
    private SpriteRenderer spr_renderer;

    Config config = new Config();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(config.lightIsOn == true)
        {
            Color c = new Color(spr_renderer.color.r, spr_renderer.color.g, spr_renderer.color.b, 1f);
            spr_renderer.color = c;
            light = true;
        }
        else if(config.lightIsOn == false)
        {
            Color c = new Color(spr_renderer.color.r, spr_renderer.color.g, spr_renderer.color.b, 0.03f);
            spr_renderer.color = c;
            light = false;

        }
		
	}
}
