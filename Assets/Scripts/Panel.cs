using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Panel : MonoBehaviour {

    public bool key_panel = true;
    Config config;
    private Fog fog = new Fog();
   public Vector3 center;
   public float radius = 0.2f;
    double i = 0.5;
    // Use this for initialization
    void OnCollisionEnter(Collision colisor)
    {
        if ((colisor.gameObject.tag == "Player"))
        {
            if (Input.GetAxisRaw("X360_Start") < 0)
            {
                print("X360_Start arrow key is held down");
                key_panel = false;
            }
            //key_panel = false;
            // Destroy(gameObject);
            if (Input.GetAxisRaw("X360_Back") < 0)
            {
                key_panel = true;
                // Destroy(gameObject);
            }


        } 
   }
    void Start () {
        config = Config.getInstance();
	}
	
	// Update is called once per frame
	void Update () {
        if(key_panel == true)
        {
            config.lightIsOn = true;
        }
        else if (key_panel == false)
        {
            config.lightIsOn = false;

          
        }

     /*  if (Input.GetAxisRaw("X360_Start") < 0)
        {


            key_panel = false;
           // Destroy(gameObject);
        }
        if ( Input.GetAxisRaw("X360_Back") < 0)
        {
            key_panel = true;
            // Destroy(gameObject);
        }
*/

    }
   
}
