using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

    public int playersDied = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (playersDied == 4)
        {
            SceneManager.LoadScene("SceneDied");
        }		
	}
}
