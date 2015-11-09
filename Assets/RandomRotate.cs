using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {

	private Vector3 randDir;

	private Rigidbody rb;
	private float fwdForce = 1;
	private float repeatRate = .25f;
	private Vector3 origin = new Vector3 (0,0,0);
	// Use this for initialization
	void OnEnable () 
	{
		rb = GetComponent<Rigidbody> ();
		InvokeRepeating ("MoveForward", 0, repeatRate);
		InvokeRepeating ("RandomRotation", 0, repeatRate);
	}




	void RandomRotation()
	{
		Vector3 randVector = new Vector3 (Random.Range (-360, 360), Random.Range (-360, 360), Random.Range (-360, 360));
		rb.AddRelativeTorque (randVector);
	}

	void MoveForward()
	{
		rb.AddForce (Vector3.forward * fwdForce);
		float dist = Vector3.Distance(origin, transform.position);
		//Debug.Log ("dist: " + dist + " name: " + gameObject);
		if (dist > 500) {
			transform.position = origin;
			Debug.Log ("reset " + transform.position);
		}
			
	}
}
