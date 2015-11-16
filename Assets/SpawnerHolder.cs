using UnityEngine;
using System.Collections;

public class SpawnerHolder : MonoBehaviour {

	public SpawnObject[] spawners;
	public MeshCombiner meshCombiner;
	public Transform cubeTrunk;

	void Start()
	{
		SpawnAll ();
	}

	// Use this for initialization
	void SpawnAll () 
	{
//		Debug.Log ("spawnAll " + meshCombiner);
		foreach (SpawnObject spawner in spawners) 
		{
			spawner.Loop();
		}
		meshCombiner.Combine ();
		//transform.position = new Vector3 (-2, -3.5f, 0);
		cubeTrunk.localScale = new Vector3 (Random.Range (.125f, .5f), Random.Range (9, 18), Random.Range (.15f, .5f));
		cubeTrunk.position = new Vector3 (transform.position.x, cubeTrunk.localScale.y * .5f,transform.position.z);
		transform.position = new Vector3 (0, 0 + cubeTrunk.localScale.y * .9f,0);
//		Debug.Log ("transform.position " + transform.position);
	}

}
