using UnityEngine;
using System.Collections;

public class AudioOptimizer : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("SoundBox"))
		{
			RandomSingle otherScript = other.GetComponent<RandomSingle>();
			otherScript.inRange = true;
		}
		   
	}

	void OnTriggerExit(Collider other)
	{
			if (other.CompareTag("SoundBox"))
			    {
				RandomSingle otherScript = other.GetComponent<RandomSingle>();
				if (otherScript)
				otherScript.inRange = true;

				NotePlant notePlant = other.GetComponent<NotePlant>();
				if(notePlant)
				notePlant.inRange = true;
			}
	}

	
}
