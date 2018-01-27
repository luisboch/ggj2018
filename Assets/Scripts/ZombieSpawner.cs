using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public int enemies;
    public GameObject enemyPrefab;
    
	// Use this for initialization
	void Start () {
        GameObject level = GameObject.Find("Level/Enemies");
        for (int i = 0; i < enemies; i++)
        {
            
            GameObject go = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
            //Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
            //GameObject go = Instantiate(enemyPrefab, pos, Quaternion.identity);
            go.transform.parent = level.transform;
        }
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
