using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


public class LightPanelControl : MonoBehaviour {

    Config config;

    public Vector3 center;
    public float radius = 0.5f;
    double i = 0.5;
    
    void Start () {
        config = Config.getInstance();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
    
    private bool inRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, radius);
        return colliders.Any(collider => collider.gameObject.CompareTag("Player"));
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (inRange())
            {
                config.lightIsOn = !config.lightIsOn;
            }
        }
    }
}
