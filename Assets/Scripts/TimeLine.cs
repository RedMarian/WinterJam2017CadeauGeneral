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

	public IEnumerator TimeLineNeckbreack(){
		vidClip = vidContainer.clips [5];
		vidplay.Play ();
		yield return null;
	}

	public IEnumerator TimeLineSerpentine(){
		vidClip = vidContainer.clips [6];
		vidplay.Play ();
		yield return null;
	}

	public IEnumerator TimeLineBanderole(){
		vidClip = vidContainer.clips [7];
		vidplay.Play ();
		yield return null;
	}

	public IEnumerator TimeLineToLine(){
		vidClip = vidContainer.clips [8];
		vidplay.Play ();
		yield return new WaitForSeconds((float)vidClip.length);
		//Faire apparaitre la ligne, l'animer pour qu'elle vible beaucoup sur toute la longueur, puis moins, puis plus du tout sauf au dessus du personnag du milieu
		//Une fois ça fini, lancer la video de transformation en piques
		/*vidClip = vidContainer.clips [9];
		vidplay.Play ();*/
	}

}
