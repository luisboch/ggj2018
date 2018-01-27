using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{

	public float Speed = 1;
	public float Angle = 15;
	private double _startAngle;
	private LineOfSight _lineOfSight;
	
	// Use this for initialization
	void Start ()
	{
		_startAngle = transform.eulerAngles.y;
		_lineOfSight = GetComponentInChildren<LineOfSight>();
	}
	
	void Update()
	{
		var currentAngle = transform.eulerAngles.y;
		var currentAngleLocal = transform.localEulerAngles.y;
		var minAngle = _startAngle - Angle;
		var maxAngle = _startAngle + Angle;

		
		Debug.Log("Min Angle: " + minAngle + " Max Angle: " + maxAngle + " Current Angle: " + currentAngle + " Local Current Angle: " + currentAngleLocal);
		if (currentAngle > maxAngle)
		{
			Speed *= -1;
		}
		
		transform.eulerAngles += new Vector3(0, Speed, 0);
		
		if (_lineOfSight.SeeByTag("Player")) {
			_lineOfSight.SetStatus(LineOfSight.Status.Alerted);
		} else {
			_lineOfSight.SetStatus(LineOfSight.Status.Idle);
		}
	}
}
