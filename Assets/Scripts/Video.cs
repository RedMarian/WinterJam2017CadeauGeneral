using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour {

	public VideoClip[] clips;
	
	private int current;
	private VideoPlayer player;

	void Start() {
		current = 0;

		player = GetComponent<UnityEngine.Video.VideoPlayer>();
		player.clip = clips[current];
		player.isLooping = true;
		player.loopPointReached += EndReached;
		player.Play();

	}

	void Update() {
		
		Shader.SetGlobalTexture("_VideoTexture", player.texture);
	}

	void EndReached (UnityEngine.Video.VideoPlayer vp) {

	}
}
