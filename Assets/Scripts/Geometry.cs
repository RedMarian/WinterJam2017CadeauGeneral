using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry {

	static public GameObject GetQuad (string name, Material material, Transform root = null) {
		GameObject meshGameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
		meshGameObject.name = name;
		meshGameObject.GetComponent<Renderer>().material = material;
		meshGameObject.transform.parent = root;
		meshGameObject.transform.localPosition = Vector3.zero;
		meshGameObject.transform.localScale = Vector3.one;
		meshGameObject.transform.localRotation = Quaternion.identity;	
		meshGameObject.GetComponent<MeshCollider>().convex = true;
		return meshGameObject;
	}
}