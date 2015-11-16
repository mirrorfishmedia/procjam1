using UnityEngine;
using System.Collections;

public class NotePlant : MonoBehaviour {

	//private RandomChord randomChord;
	private AudioSource source;
	public AudioClip myClip;
	public int loopLength = 3;
	private float repeatRate;
	public bool inRange = false;


	void OnEnable ()
	{
		//randomChord = GetComponent<RandomChord> ();
		source = GetComponent<AudioSource> ();
		//repeatRate = loopLength * .25f;
		repeatRate = Random.Range (.125f, 3);
		InvokeRepeating ("Chime", 0, repeatRate);
	}

	void Chime()
	{
		if (inRange) {
			source.clip = myClip;
			//		Debug.Log ("myclip " + myClip);
			source.Play ();

		}
		}


}
