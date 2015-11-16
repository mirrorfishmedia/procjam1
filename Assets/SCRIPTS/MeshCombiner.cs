﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombiner : MonoBehaviour {
	
	MeshCollider meshCollider;
	
	void Awake() 
	{
		meshCollider = GetComponent<MeshCollider> ();
	}
	
	public void Combine()
	{
//		Debug.Log ("combining");
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
//		Debug.Log ("Meshfilters: " + meshFilters.Length);
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		int i = 0;
		while (i < meshFilters.Length) {
			combine[i].mesh = meshFilters[i].sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].gameObject.active = false;
			i++;
		}
		transform.GetComponent<MeshFilter>().mesh = new Mesh();
		transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
		transform.gameObject.active = true;
		//meshCollider.sharedMesh = null;
		//meshCollider.sharedMesh = transform.GetComponent<MeshFilter>().mesh;
	}
}