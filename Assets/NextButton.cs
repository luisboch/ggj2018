using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.transform.position == new Vector3(17, 0, -10))
        {
            if (((Input.GetButtonDown("X360_A01"))))
            {
                SceneManager.LoadScene(Config.getInstance().GetNextScene());
            }
        }
	}
}
