using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.VR;

public class DayNight : MonoBehaviour {
	
	public Light sun;
	//public Light moon;
	public float secondsInFullDay = 120f;
	[Range(0,1)]
	public float currentTimeOfDay = 0;
	[HideInInspector]
	public float timeMultiplier = 1f;
	public Color fogColorDay;
	
	float sunInitialIntensity;
	float ambientInitialIntensity;
	public Transform player;
	public AudioMixerSnapshot[] snapshots;
	public AudioMixer mixer;
	public GameObject VRPlayer;
	public GameObject FPSPlayer;
	public Transform playerSpawn;

	private float[] weights;

	
	
	void Start() {
		sunInitialIntensity = sun.intensity;
		ambientInitialIntensity = RenderSettings.ambientIntensity;
		weights = new float[2];
		if (VRDevice.isPresent) {
			SpawnPlayer (VRPlayer);
		} else 
		{
			SpawnPlayer (FPSPlayer);
		}

	}

	void SpawnPlayer(GameObject pf)
	{
		GameObject spawnedPlayer = Instantiate (pf, playerSpawn.position, Quaternion.identity)as GameObject;
		player = spawnedPlayer.transform;
	}

	void Update() {
		UpdateSun();
		
		//currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
		float playerDistance = player.position.z / 307f;
//		Debug.Log ("playerDistance = " + playerDistance);
		weights [0] = 1 - playerDistance;
		weights [1] = 1 - weights [0];
		currentTimeOfDay = playerDistance + .17f;
		mixer.TransitionToSnapshots (snapshots, weights, Time.deltaTime);

		if (currentTimeOfDay >= 1) {
			currentTimeOfDay = 0;
		}
	}
	
	void UpdateSun() {
		sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

		
		float intensityMultiplier = 1;
		float ambientIntensityMultiplier = 0;
		if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
			intensityMultiplier = 0F;
			//ambientIntensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.1f) * (1 / 0.02f));
			
			//RenderSettings.fogColor = Color.black;
			
		}
		else if (currentTimeOfDay <= 0.25f) {
			intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
			//moonIntensityMultiplier = 1f - intensityMultiplier;
			//RenderSettings.fogColor = fogColorDay;
		}
		else if (currentTimeOfDay >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
			//moonIntensityMultiplier = 1f - intensityMultiplier;
		}
		
		sun.intensity = sunInitialIntensity * intensityMultiplier;
		RenderSettings.fogColor = fogColorDay * intensityMultiplier;
		RenderSettings.ambientIntensity = ambientInitialIntensity * intensityMultiplier;
		
	}
}