using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject obj;
	public float radius = 50;
	public int numObjects = 10;
	public float verticalRadius = 0;
	public Vector2 scaleRange = new Vector2 (1,1);
	public bool randomizeScale;
	public bool randomizeRotation;
	public bool spawnOnStart = true;
	public bool parentToSpawner = false;


	// Use this for initialization
	void Start () 
	{
		if (spawnOnStart)
		Loop ();

	}

	public void Loop()
	{
		for (int i = 0; i < numObjects; i++)
		{
			Spawn();
		}
	}
	
	void Spawn()
	{
		GameObject clone = Instantiate (obj, GetRandomPoint () + transform.position, transform.rotation) as GameObject;

		if (randomizeRotation) {
			clone.transform.rotation = Random.rotation;
		}

		if (randomizeScale) 
		{
			Vector3 randScale = new Vector3 (Random.Range (scaleRange.x, scaleRange.y), Random.Range (scaleRange.x, scaleRange.y), Random.Range (scaleRange.x, scaleRange.y));
			clone.transform.localScale = randScale;
		}

		if (parentToSpawner) 
		{
			clone.transform.SetParent(this.transform);
		}

	}

	Vector3 GetRandomPoint()
	{
		Vector3 spherePos = Random.insideUnitSphere * radius;
		spherePos.y = Random.Range (-1, 1f) * verticalRadius;
		//Vector3 pos = new Vector3 (Random.Range (-1,1f) * radius, Random.Range (-1,1f) * verticalRadius, Random.Range (-1,1f) * radius);
		return spherePos;
		
	}
}
