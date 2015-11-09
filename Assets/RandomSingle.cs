using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class RandomSingle : MonoBehaviour {
	
	public AudioClip[] clips;
	public  Vector2 loopOffsetRange = new Vector2 (.1f, .5f);
	public float jumpForce = 5000;
	public bool flier;

	private float spawnRange = 100;
	private int numNotePlants = 10;
	
	private AudioSource source;
	private Rigidbody rb;
	
	
	void OnEnable()
	{
		source = GetComponent<AudioSource> ();
		source.clip = clips [Random.Range (0, clips.Length)];
		InvokeRepeating("Jump", Random.Range (loopOffsetRange.x, loopOffsetRange.y), Random.Range (loopOffsetRange.x, loopOffsetRange.y));
		rb = GetComponent<Rigidbody> ();
	}
	
	// Use this for initialization
	void Start () 
	{
//		source.clip = myPlant.chordSample;

//		for (int i = 0; i < numNotePlants; i++) 
		//{
			//Vector3 offsetPos = new Vector3 (Random.Range (0,15f), 0, Random.Range (0,15f));
//			GameObject clone = Instantiate(notePlantPf, transform.position + offsetPos, Random.rotation) as GameObject;
//			NotePlant newPlant = clone.GetComponent<NotePlant>();
//			newPlant.myClip = myPlant.allowedNotes[Random.Range (0, myPlant.allowedNotes.Length)];
//			newPlant.loopLength = Random.Range(myPlant.minRate, myPlant.maxRate);
		//}
	}
	
	
	
	void Jump()
	{
		
		rb.AddForce (Vector3.up * jumpForce);
		source.Play ();
		
		
	}
	
//	void OnCollisionEnter()
//	{
//		source.Play ();
//	}
}
