using UnityEngine;
using System.Collections;

//???
using EasyMobile;

///Developed By Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

[DisallowMultipleComponent]
public class Bubbles : MonoBehaviour
{
	public static Bubbles instance;

	// Use this for initialization
	void Awake ()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
//???		
#if UNITY_ANDROID
		if (GameServices.IsInitialized()) {
		} else {
			GameServices.Init();
		} 
#endif	
		
	}
}
