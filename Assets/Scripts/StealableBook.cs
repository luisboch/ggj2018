using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealableBook : MonoBehaviour
{

	public float Radius = 0.3f;
	
	// Use this for initialization
	void Start () {
		
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, Radius);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("X360_A01"))
		{
			Collider[] col = Physics.OverlapSphere(transform.position, Radius);
			foreach (Collider c in col)
			{
				if (c.tag.Equals("Player"))
				{
					//Logica de pegar o livro de info
				}
			}
		}
	}
}
