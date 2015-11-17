using UnityEngine;
using System.Collections;

public class CollisionChecker : MonoBehaviour {

	void OnCollisionEnter()
	{
		Debug.Log ("OCE");

	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("OTE: " + other);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
