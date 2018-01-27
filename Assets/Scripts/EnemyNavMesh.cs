using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour {

    private Transform target;
    private NavMeshAgent navMeshAgent;
    public int lives = 3;

	// Use this for initialization
	void Start () {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        target = FindClosestEnemy();
        if(target)
        {
            navMeshAgent.SetDestination(target.position);
        }
	}

    Transform FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        if(gos.Length == 0)
        {
            return null;
        }
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest.transform;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("colidiu tiro");
            Destroy(col.gameObject);
            TookDamage();
        }
    }

    void TookDamage()
    {
        lives--;
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }

}
