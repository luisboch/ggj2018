using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Transmissor : MonoBehaviour {

    public float radius = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("X360_A01"))
        {
            if (inRange())
            {
                if (Config.getInstance().IsAllInfosCollected())
                {    
                    Debug.Log("All infos collected!!!");
                    SceneManager.LoadScene("SceneBase");
                }
                else
                {
                    Debug.Log("Go get the infos MF!!!");
                }
            }
        }

        
	}

    private bool inRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, radius);
        return colliders.Any(collider => collider.gameObject.CompareTag("Player"));
    }

}
