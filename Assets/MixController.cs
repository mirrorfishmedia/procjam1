using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MixController : MonoBehaviour {

	public AudioMixerSnapshot dryMix;
	public AudioMixerSnapshot lowpassDown;
	private DayNight dayNight;
	private float transitionTime;

	// Use this for initialization
	void Start () 
	{
		dayNight = GetComponent<DayNight> ();
		transitionTime = dayNight.secondsInFullDay;
		lowpassDown.TransitionTo (.01f);
		Invoke ("DryMix", .1f);
		
		Invoke ("LowpassDown", transitionTime * .51f);

	}

	void DryMix()
	{
		dryMix.TransitionTo (transitionTime * .5f);
	}

	void LowpassDown()
	{
		lowpassDown.TransitionTo (transitionTime * .5f);
	}

}
