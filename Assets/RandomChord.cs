using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (Rigidbody))]
public class RandomChord : MonoBehaviour {

	public AudioClip[] clips;
	public float loopTime = .25f;
	public  Vector2 loopOffsetRange = new Vector2 (.1f, .5f);
	public float jumpForce = 5000;
	public bool flier;
	public PlantObject[] plants;
	public GameObject notePlantPf;
	private PlantObject myPlant;

	private float spawnRange = 100;
	private int numNotePlants = 10;

	private AudioSource source;
	private Rigidbody rb;


	void OnEnable()
	{
		source = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody> ();
		myPlant = plants [Random.Range (0, plants.Length)];
	}

	// Use this for initialization
	void Start () 
	{
		source.clip = myPlant.chordSample;
		InvokeRepeating("Jump", Random.Range (loopOffsetRange.x, loopOffsetRange.y), Random.Range (loopOffsetRange.x, loopOffsetRange.y));
		for (int i = 0; i < numNotePlants; i++) 
		{
			Vector3 offsetPos = new Vector3 (Random.Range (0,15f), 0, Random.Range (0,15f));
			GameObject clone = Instantiate(notePlantPf, transform.position + offsetPos, Random.rotation) as GameObject;
			NotePlant newPlant = clone.GetComponent<NotePlant>();
			newPlant.myClip = myPlant.allowedNotes[Random.Range (0, myPlant.allowedNotes.Length)];
			newPlant.loopLength = Random.Range(myPlant.minRate, myPlant.maxRate);
		}
	}
	
	

	void Jump()
	{

		//rb.AddForce (Vector3.up * jumpForce);
		//if (flier)
		source.Play ();


	}

	void OnCollisionEnter()
	{
		source.Play ();
	}
}
