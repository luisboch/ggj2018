using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public float ammoTimer;
    public float ammoTime;

	// Use this for initialization
	void Start () {
        ammoTimer = ammoTime;
	}
	
	// Update is called once per frame
	void Update () {
		ammoTimer -= Time.deltaTime;
        if(ammoTimer <= 0)
        {
            Destroy(gameObject);
        }
	}
}
