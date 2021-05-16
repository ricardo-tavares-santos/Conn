using UnityEngine;
using UnityEngine.UI;
using System.Collections;

///Developed By Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

[DisallowMultipleComponent]
public class Missions : MonoBehaviour
{
	// Use this for initialization
	void Awake ()
	{
		DataManager.instance.InitGameData (transform, "OnInitGameDataDone");
	}

	private void OnInitGameDataDone ()
	{
		//Do somthing
	}
}
