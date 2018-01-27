using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Panel : MonoBehaviour {

    public bool panelOn;
    Config config;
    private Fog fog = new Fog();
    public Vector3 center;
    public float radius = 0.5f;
    double i = 0.5;
    
    void Start () {
        config = Config.getInstance();
        panelOn = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
    
    private bool inRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, radius);
        //foreach (Collider c in colliders)
        //{
        //    if (c.tag.Equals("Player"))
        //    {
        //        return true;
        //    }
        //}
        //return false;
        return colliders.Any(collider => collider.gameObject.CompareTag("Player"));
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("X360_A01"))
        {
            if (inRange())
            {
                panelOn = !panelOn;
            }
        }
    }
}
