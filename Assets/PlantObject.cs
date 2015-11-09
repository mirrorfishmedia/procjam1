using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlantObject : ScriptableObject {
	public AudioClip chordSample;
	public AudioClip[] allowedNotes;
	public int minRate = 1;
	public int maxRate = 8;

	
	
}
