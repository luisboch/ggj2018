using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float velocity;
    private Vector3 direction;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        //transform.rotation = Quaternion.Euler(90, 0, 0);
        rb = GetComponent<Rigidbody>();
        //direction = Vector2.right; // (1,0)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction * velocity;
    }

    public void StartDirection(Vector3 _direction)
    {
        direction = _direction;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision colisor)
    {
        if ((colisor.gameObject.tag == "Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col) {

        if ((col.gameObject.tag == "parede"))
        {
            Destroy(gameObject);
        }
    }
}
