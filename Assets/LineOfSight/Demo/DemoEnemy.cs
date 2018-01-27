using UnityEngine;

public class DemoEnemy : MonoBehaviour
{
    // STEP 1: Access to line of sight
    private LineOfSight _lineOfSight;

    // ONLY FOR DEMO: Speed for demo movement
    private float _movementSpeed = -5;

    private void Start()
    {
        // STEP 2: Get line of sight script component
        _lineOfSight = GetComponentInChildren<LineOfSight>();
    }

    private void FixedUpdate()
    {
        // ONLY FOR DEMO: Just simple left and right movement for demo
        if (transform.position.x < -10 || transform.position.x > 10) _movementSpeed *= -1;
        transform.position = new Vector3(transform.position.x + _movementSpeed*Time.fixedDeltaTime, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        // STEP 3: Automatically check if viewer sees anything marked by given tag
        if (_lineOfSight.SeeByTag("Player"))
        {
            // STEP 4: Change the color of viewing area
            _lineOfSight.SetStatus(LineOfSight.Status.Alerted);
        }
        else
        {
            // STEP 5: Change the color of viewing area back to normal
            _lineOfSight.SetStatus(LineOfSight.Status.Idle);
        }
    }
}