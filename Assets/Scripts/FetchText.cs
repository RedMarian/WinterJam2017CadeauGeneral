using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchText : MonoBehaviour {

	public Text[] texts;
	private string[] words;
	private string final;
	private string[] filePaths;
	private string dataPath;

	void Start () {

		dataPath = Application.dataPath;
		List<string> paths = new List<string>(dataPath.Split('/'));
		paths.RemoveAt(paths.Count - 1);
		dataPath = String.Join("/", paths.ToArray());
		StartCoroutine(LoadWords(System.IO.Path.Combine(dataPath, "Text/content.txt")));
		StartCoroutine(LoadFinal(System.IO.Path.Combine(dataPath, "Text/final.txt")));
	}

	IEnumerator LoadWords(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		words = www.text.Split('\n');
		SetRandomText();
	}

	IEnumerator LoadFinal(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		final = www.text;
	}

	string GetRandomText ()
	{
		return words[(int)UnityEngine.Random.Range(0,words.Length)];
	}

	public void SetRandomText ()
	{
		foreach (Text text in texts) {
			text.text = GetRandomText();
		}
	}

}
