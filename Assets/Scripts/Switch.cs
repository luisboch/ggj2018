using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public bool on;
    public float radius = 0.3f;

	// Use this for initialization
	void Start () {
        on = false;
	}
	
    void FixedUpdate()
    {
        if( Input.GetButtonDown("Fire1") || SimpleMobileController.GetInstance().getAction1())
        {
            Collider[] col = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider c in col)
            {
                if (c.tag.Equals("Player"))
                {
                    on = !on;
                }
            }
        }
    }

    //void OnTriggerStay(Collider col)
    //{
    //    //Debug.Log("Collision");
    //    if (Input.GetAxisRaw("X360_A01") < 0 || Input.GetAxisRaw("X360_A01") > 0)
    //    {
    //        on = !on;
    //    }

    //}

}
