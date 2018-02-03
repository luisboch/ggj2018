using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    public float fadeTime = 2.0f;

	// Update is called once per frame
	void Update () 
    {
		if ( Input.GetButtonDown("Fire1") || SimpleMobileController.GetInstance().getAction1())
        {
            Initiate.Fade("Menu", Color.black, fadeTime);
        }
	}
}
