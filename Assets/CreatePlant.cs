using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreatePlant {
	
	[MenuItem("Assets/Create/Plant")]
	public static void CreateWeaponObject()
	{
		PlantObject asset = ScriptableObject.CreateInstance<PlantObject> ();
		
		AssetDatabase.CreateAsset (asset, "Assets/PlantObject.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
		
	}
}
