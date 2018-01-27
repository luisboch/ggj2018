using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject ammoPrefab;
    public GameObject lifePrefab;

	// Use this for initialization
	void Start () {
        GameObject level = GameObject.Find("Level/PowerUps");

        int randPowerUp = (int)Random.Range(1.0f, 10.0f);
        if(randPowerUp <= 2)
        {
            GameObject go2 = Instantiate(lifePrefab, gameObject.transform.position + new Vector3(0.5f, -0.25f, 0.0f), gameObject.transform.rotation);
            go2.transform.parent = level.transform;
        }
        else
        {
            GameObject go = Instantiate(ammoPrefab, gameObject.transform.position + new Vector3(-0.5f, -0.25f, 0.0f), gameObject.transform.rotation);
            go.transform.parent = level.transform;
        }
        
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
