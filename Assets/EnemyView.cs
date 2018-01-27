using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour {

    private LineOfSight _lineOfSight;

	// Use this for initialization
	void Start () 
    {
        _lineOfSight = GetComponentInChildren<LineOfSight>();
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
