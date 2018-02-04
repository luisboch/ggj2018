using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public float fadeTime = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || SimpleMobileController.GetInstance().getAction1())
        {
            goToMenu();
        }
    }

    public void goToMenu(){
        Initiate.Fade("Menu", Color.black, fadeTime);
    }
}
