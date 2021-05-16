using UnityEngine;
using UnityEngine.UI;

public class LocalisedText : MonoBehaviour {

	public static LocalisedText instance;
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}
	

    public string key;

	void Start () {
        GetComponent<Text>().text = GameObject.Find("EventSystem").GetComponent<LocalisationTexts>().GetLocalisedText(key).ToUpper();
	}
}