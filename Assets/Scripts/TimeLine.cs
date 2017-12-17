using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TimeLine : MonoBehaviour {

	bool boolH;
	VideoPlayer vidplay;
	VideoClip vidClip;
	Video vidContainer;

	void Start () {
		boolH = this.gameObject.GetComponent<ConnectManager> ().HandHolding;
		vidplay = this.gameObject.GetComponent<VideoPlayer> ();
		vidClip = vidplay.clip;
		vidContainer = this.gameObject.GetComponent<Video> ();
		StartCoroutine(TheTimeLineStart());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator TheTimeLineStart(){
		yield return new WaitForSeconds(5);
		if (!boolH) {
			vidClip = vidContainer.clips [0];
			vidplay.Play ();
			yield return new WaitForSeconds((float)vidClip.length);
			while (!boolH) {
				vidClip = vidContainer.clips [1];
				vidplay.Play ();
			}
			if (boolH) {
				vidClip = vidContainer.clips [2];
				vidplay.Play ();
				yield return new WaitForSeconds ((float)vidClip.length);
			}
		} //else if (boolH) {
		//	vidClip = vidContainer.clips [0];
		//	vidplay.Play ();
		//}

		yield return new WaitForSeconds((float)vidClip.length);
	}

	public IEnumerator TimeLineTouribillon(){
		while (boolH) {
			vidClip = vidContainer.clips [3];
			vidplay.Play ();
		}
		yield return null;
	}

	public IEnumerator TimeLineTourbillonDisperse(){
		vidClip = vidContainer.clips [4];
		vidplay.Play ();
		yield return null;
	}
}
