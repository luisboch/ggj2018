using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Text timer;
    float timeRemaining = 180f;

	// Use this for initialization
	void Start () {
        timer = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timeRemaining -= Time.deltaTime;

        float minutes = Mathf.Floor(timeRemaining / 60);
        float seconds = (timeRemaining % 60);

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (timeRemaining <= 0)
        {
            //Apresentar tela de vitória
            SceneManager.LoadScene("SceneVictory");
        }
	}
}
