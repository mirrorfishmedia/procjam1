using UnityEngine;
using System.Collections;

public class RandMaterial : MonoBehaviour {

	public Material[] materials;

	private MeshRenderer meshRenderer;

	// Use this for initialization
	void OnEnable () 
	{
		meshRenderer = GetComponent<MeshRenderer> ();
		meshRenderer.material = materials [Random.Range (0, materials.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
