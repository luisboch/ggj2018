using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    private SpriteRenderer spr_renderer;
    public float timer = 10;
    private bool lightsOn = false;

    private List<GameObject> PlayersCollisions = new List<GameObject>();

    // Use this for initialization
    void Start () {
		LightsOff();
    }

    void Awake()
    {
        spr_renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        
        if (timer <= 0 && lightsOn)
        {
            LightsOff();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            LightsOn();
            timer = 10;
            PlayersCollisions.Add(col.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayersCollisions.Remove(col.gameObject);

        if (PlayersCollisions.Count == 0) {
            LightsOff();
        }
    }

	void LightsOn () {
		Color c = new Color(spr_renderer.color.r, spr_renderer.color.g, spr_renderer.color.b, 1f);
		spr_renderer.color = c;
        lightsOn = true;
	}

	void LightsOff() {
		Color c = new Color(spr_renderer.color.r, spr_renderer.color.g, spr_renderer.color.b, 0.03f);
		spr_renderer.color = c;
        lightsOn = false;
    }

}
