using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buddy {

	public GameObject gameObject;
	public GameObject armLeft;
	public GameObject armRight;
	public Vector2 position;
	public Vector2 velocity;

	public Buddy (Material material, Transform root = null) {

		gameObject = Geometry.GetQuad("Buddy", material, root);
		position = new Vector2(UnityEngine.Random.Range(-2f,2f), UnityEngine.Random.Range(-2f,2f));
		Vector3 pos = new Vector3(0,0,0);
		pos.x = position.x;
		pos.y = position.y;
		gameObject.transform.localPosition = pos;

		Material materialArm = new Material(Shader.Find("Unlit/Arm"));
		materialArm.mainTexture = Resources.Load("Textures/arm") as Texture;
		armLeft = Geometry.GetQuad("Arm Left", materialArm, gameObject.transform);
		armLeft.transform.Translate(Vector3.left);
		armLeft.transform.Rotate(Vector3.forward * 180f);
		armRight = Geometry.GetQuad("Arm Right", materialArm, gameObject.transform);
		armRight.transform.Translate(Vector3.right);
	}

	public void Update () {
		Vector3 pos = gameObject.transform.localPosition;
		pos.x = position.x;
		pos.y = position.y;
		gameObject.transform.localPosition = pos;
	}
}
