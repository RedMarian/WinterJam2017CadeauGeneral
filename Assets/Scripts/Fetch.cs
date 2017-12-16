using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fetch : MonoBehaviour {

	public Shader shader;
	[Header("Areas")]
	public float boidRadius = 1f;
	public float followRange = 1f;
	[Header("Velocity")]
	public float velocitySpeed = .1f;
	public float velocityFriction = .9f;
	public float velocityDamping = .1f;
	public float velocityMax = 3f;
	[Header("Boid")]
	public float avoidScale = 2f;
	public float targetScale = 1f;
	public float followScale = 1f;

	private string dataPath;
	private string[] filePaths;
	private List<Texture2D> textures;
	private List<Buddy> buddies;

	void Start () {
		Fecth();
	}

	void Update () {

		foreach (Buddy buddy in buddies) {

			Vector2 velocity = new Vector2(0,0);
			Vector2 target = (Vector2.zero - buddy.position).normalized;
			Vector2 avoid = new Vector2(0,0);
			Vector2 follow = new Vector2(0,0);
			foreach (Buddy other in buddies) {
				float dist = Vector2.Distance(buddy.position, other.position);
				float radius = boidRadius * 2f;
				Vector2 dir = buddy.position-other.position;
				if (dist < radius && dist > 0.0001f) {
					avoid += dir.normalized * Mathf.Max(boidRadius, dir.magnitude);
				}
				if (dist < followRange && dist > 0.0001f) {
					follow += other.velocity;
				}
			}

			velocity += avoid * avoidScale;
			velocity += follow * followScale;
			velocity += target * targetScale;
			velocity = velocity.normalized * Mathf.Min(velocityMax, velocity.magnitude);

			buddy.velocity = Vector2.Lerp(buddy.velocity * velocityFriction, velocity, velocityDamping);
			buddy.position += buddy.velocity * velocitySpeed;

			buddy.Update();
		}	
	}

	void Fecth () {
		dataPath = Application.dataPath;
		List<string> paths = new List<string>(dataPath.Split('/'));
		paths.RemoveAt(paths.Count-1);
		dataPath = String.Join("/", paths.ToArray());
		dataPath = System.IO.Path.Combine(dataPath, "Heads/");
		var info = new DirectoryInfo(dataPath);
		FileInfo[] fileInfos = info.GetFiles();
		filePaths = new string[fileInfos.Length];
		textures = new List<Texture2D>();
		buddies = new List<Buddy>();
		for (int i = 0; i < fileInfos.Length; ++i) {
			filePaths[i] = "file://" + dataPath + fileInfos[i].Name;
			StartCoroutine(Load(filePaths[i]));
		}
	}

	IEnumerator Load (string url) {
		WWW www = new WWW(url);
		yield return www;
		textures.Add(www.texture);
		Material material = new Material(shader);
		material.SetTexture("_MainTex", www.texture);
		Buddy buddy = new Buddy(material, transform);
		buddies.Add(buddy);
	}
}
