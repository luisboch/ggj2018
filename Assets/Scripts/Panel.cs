using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Panel : MonoBehaviour {

    public bool key_panel = true;
    Config config;
    private Fog fog = new Fog();
    public Vector3 center;
    private const float Radius = 1.2f;
    double i = 0.5;
    
    void Start () {
        config = Config.getInstance();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
    
    private bool inRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, Radius);

        return colliders.Any(collider => collider.gameObject.CompareTag("Player"));
    }


    // Update is called once per frame
    void Update ()
    {
        
        if (inRange()) {
            if (Input.GetAxisRaw("X360_Start") < 0)
            {
                key_panel = false;
            }   
            
            if (Input.GetAxisRaw("X360_Back") < 0)
            {
                key_panel = true;
            }
        }
        
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