using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

///Developed By Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

public class Logo : MonoBehaviour {

	public float sleepTime = 5;

	// Use this for initialization
	void Start () {
		Invoke ("LoadMainScene", sleepTime);
	}

	private void LoadMainScene(){
		StartCoroutine(SceneLoader.LoadSceneAsync("Main"));
	}
	
}
