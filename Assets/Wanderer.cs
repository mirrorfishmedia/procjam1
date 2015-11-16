using UnityEngine;
using System.Collections;

public class Wanderer : MonoBehaviour {

	private Rigidbody rb;
	private bool flyingOff;

	private float upForce = 75;
	private float fwdForce = 25;

	private float turnRate = .1f;

	private AudioSource source;

	public AudioClip[] clips;


	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody> ();
		source = GetComponent<AudioSource> ();
		source.clip = clips [Random.Range (0, clips.Length)];
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (flyingOff) 
		{
			rb.AddRelativeForce(Vector3.up * upForce);
			rb.AddRelativeForce(Vector3.forward * fwdForce);
		}
	}

	void OnTriggerEnter (Collider other)
	{
//		Debug.Log ("OTE");
		if (other.gameObject.CompareTag ("Player")) {
			flyingOff = true;
			InvokeRepeating("RandRotation",0,turnRate);
		}
	}

	void RandRotation()
	{
		Quaternion randRotation = Random.rotation;
		transform.rotation = randRotation;
		source.Play ();
	}

	void PlaySound()
	{
		//source.Play ();
	}

}
