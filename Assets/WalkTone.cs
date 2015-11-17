using UnityEngine;
using System.Collections;

public class WalkTone : MonoBehaviour {

	private AudioSource source;

	public AudioClip clip;



	void Awake()
	{
		source = GetComponent<AudioSource> ();
	}



	// Update is called once per frame
	void Update () 
	{
		//source.pitch = Mathf.Abs(Input.GetAxis ("Vertical"));
		//Time.timeScale = Mathf.Abs(Input.GetAxis ("Vertical") + .01f);
		//Debug.Log ("source.pitch : " + source.pitch);
	}
}
