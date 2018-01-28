using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Camera.main.transform.position == new Vector3(17, 0, -10))
        {
            if (Input.GetButtonDown("X360_B01"))
            {
                Camera.main.transform.position = new Vector3(0, 0, -10);
            }
        }

    }
}
