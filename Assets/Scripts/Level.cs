using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public float zombieSpawnTime = 5;
    public float zombieSpawnTimer;
    public float powerUpSpawnTime = 10;
    public float powerUpSpawnTimer;
    public GameObject zombieSpawnerPrefab;
    public GameObject powerUpSpawnerPrefab;

	// Use this for initialization
	void Start () {
        zombieSpawnTimer = zombieSpawnTime;
        powerUpSpawnTimer = powerUpSpawnTime;
	}
	
	// Update is called once per frame
	void Update () {
        zombieSpawnTimer -= Time.deltaTime;
        powerUpSpawnTimer -= Time.deltaTime;

        if (zombieSpawnTimer <= 0)
        {
            SpawnZombie();
        }

        if (powerUpSpawnTimer <= 0)
        {
            SpawnPowerUp();
        }
	}

    void SpawnZombie()
    {
        float rand = Random.Range(1.0f, 7.0f);
        int randRoom = ((int)rand);
        //Debug.Log(randRoom);
        zombieSpawnTimer = zombieSpawnTime;
        GameObject rooms = GameObject.Find("Fog");
        foreach (Transform child in rooms.transform)
        {
            if (child.name != "Sala" + randRoom)
            {
                //Debug.Log(child.name + " -> Continue");
                continue;
            }
            if (child.name == "Sala7")
            {
                GameObject subRooms = GameObject.Find("Sala7");
                foreach (Transform subChild in subRooms.transform)
                {
                    MeshRenderer renderer = subChild.GetComponent<MeshRenderer>();
                    if (renderer.enabled)
                    {
                        //Debug.Log(subChild.name + " renderer ligado!");
                        Instantiate(zombieSpawnerPrefab, subChild.transform.position, subChild.transform.rotation);
                        //Instantiate(spawnerPrefab, new Vector3(subChild.transform.position.x, 0.0f, subChild.transform.position.z), subChild.transform.rotation);
                        break;
                    }
                    else
                    {
                        //Debug.Log(subChild.name + " renderer desligado!");
                    }
                }
            }
            else
            {
                MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                if (renderer.enabled)
                {
                    //Debug.Log(child.name + " renderer ligado!");
                    Instantiate(zombieSpawnerPrefab, child.transform.position, child.transform.rotation);
                    //Instantiate(spawnerPrefab, new Vector3(child.transform.position.x, 0.0f, child.transform.position.z), child.transform.rotation);
                    break;
                }
                else
                {
                    //Debug.Log(child.name + " renderer desligado!");
                }
            }
        }
    }

    void SpawnPowerUp()
    {
        float rand = Random.Range(1.0f, 7.0f);
        int randRoom = ((int)rand);
        //Debug.Log(randRoom);
        powerUpSpawnTimer = powerUpSpawnTime;
        GameObject rooms = GameObject.Find("Fog");
        foreach (Transform child in rooms.transform)
        {
            if (child.name != "Sala" + randRoom)
            {
                //Debug.Log(child.name + " -> Continue");
                continue;
            }
            if (child.name == "Sala7")
            {
                GameObject subRooms = GameObject.Find("Sala7");
                foreach (Transform subChild in subRooms.transform)
                {
                    MeshRenderer renderer = subChild.GetComponent<MeshRenderer>();
                    if (renderer.enabled)
                    {
                        //Debug.Log(subChild.name + " renderer ligado!");
                        Instantiate(powerUpSpawnerPrefab, subChild.transform.position, subChild.transform.rotation);
                        //Instantiate(spawnerPrefab, new Vector3(subChild.transform.position.x, 0.0f, subChild.transform.position.z), subChild.transform.rotation);
                        break;
                    }
                    else
                    {
                        //Debug.Log(subChild.name + " renderer desligado!");
                    }
                }
            }
            else
            {
                MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                if (renderer.enabled)
                {
                    //Debug.Log(child.name + " renderer ligado!");
                    Instantiate(powerUpSpawnerPrefab, child.transform.position, child.transform.rotation);
                    //Instantiate(spawnerPrefab, new Vector3(child.transform.position.x, 0.0f, child.transform.position.z), child.transform.rotation);
                    break;
                }
                else
                {
                    //Debug.Log(child.name + " renderer desligado!");
                }
            }
        }
    }
}
