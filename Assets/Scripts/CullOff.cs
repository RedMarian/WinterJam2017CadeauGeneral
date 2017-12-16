using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CullOff : MonoBehaviour {

	void Start () {
		Bounds bounds = GetComponent<MeshFilter>().sharedMesh.bounds;
		bounds.size = Vector3.one * 1000f;
		GetComponent<MeshFilter>().sharedMesh.bounds = bounds;
	}
}
