using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buddy {

	public GameObject gameObject;
	public Vector2 position;
	public Vector2 velocity;

	public Buddy (Material material, Transform root = null) {

		gameObject = Geometry.GetQuad("Buddy", material, root);
		position = new Vector2(UnityEngine.Random.Range(-2f,2f), UnityEngine.Random.Range(-2f,2f));
		Vector3 pos = new Vector3(0,0,0);
		pos.x = position.x;
		pos.y = position.y;
		gameObject.transform.localPosition = pos;
	}

	public void Update () {
		Vector3 pos = gameObject.transform.localPosition;
		pos.x = position.x;
		pos.y = position.y;
		gameObject.transform.localPosition = pos;
	}
}
