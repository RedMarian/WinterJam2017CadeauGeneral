using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TimeLine : MonoBehaviour {

	public Animator animator;
	public Animator animatorTentacles;

	bool holdingHands;
	VideoPlayer vidplay;
	VideoClip vidClip;
	Video vidContainer;
	ConnectManager manager;

	void Start () {
		manager = gameObject.GetComponent<ConnectManager>();
		holdingHands = manager.HandHolding;
		vidplay = this.gameObject.GetComponent<VideoPlayer> ();
		vidClip = vidplay.clip;
		vidContainer = this.gameObject.GetComponent<Video> ();
		StartCoroutine(TheTimeLineStart());
	}
	
	// Update is called once per frame
	void Update () {
		holdingHands = manager.HandHolding;
		animator.SetBool("HoldingOn", holdingHands);
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("04_GoingTentacles")) {
			animatorTentacles.SetBool("Holdin", true);
		}
	}

	IEnumerator TheTimeLineStart(){
		// yield return new WaitForSeconds(5);
		// if (!holdingHands) {
			vidplay.clip = vidContainer.clips [0];
			vidplay.Play ();
			yield return new WaitForSeconds((float)vidplay.clip.length);
			vidplay.clip = vidContainer.clips [1];
			vidplay.Play ();
			while (!holdingHands) {
				yield return null;
			}
			vidplay.clip = vidContainer.clips [2];
			vidplay.Play ();
			vidplay.isLooping = false;
			yield return new WaitForSeconds ((float)vidplay.clip.length);
		// } //else if (holdingHands) {
		//	vidClip = vidContainer.clips [0];
		//	vidplay.Play ();
		//}

		yield return new WaitForSeconds((float)vidplay.clip.length);
	}

	public IEnumerator TimeLineTouribillon(){
		while (holdingHands) {
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
