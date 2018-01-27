using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework.Constraints;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
	//Rotation Sensitivity
	public float RotationSensitivity = 35.0f;
	public float minAngle = -45.0f;
	public float maxAngle = 45.0f;
     
	//Rotation Value
	float yRotate = 0.0f;
	private Vector3 _startAngle;

	private void Start()
	{
		_startAngle = transform.eulerAngles;
	}

	// Update is called once per frame
	void Update () {
         
		//Rotate Y view
		yRotate += RotationSensitivity * Time.deltaTime;
		yRotate = Mathf.Clamp (yRotate, minAngle, maxAngle);

		if (yRotate == 45 || yRotate == -45)
		{
			RotationSensitivity *= -1;
		}
		
		transform.eulerAngles = (new Vector3 (0.0f, yRotate, 0.0f)) + _startAngle;
	}
}
