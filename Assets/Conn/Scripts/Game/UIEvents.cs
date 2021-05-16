using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//???
//using EasyMobile;


///Developed By Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

[DisallowMultipleComponent]
public class UIEvents : MonoBehaviour
{
	/// <summary>
	/// A static instance of this class.
	/// </summary>
	public static UIEvents instance;
	

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	public void ShowResetGameConfirmDialog ()
	{
		//Show banner advertisment
		AdsManager.instance.ShowAdvertisment (AdPackage.AdEvent.Event.ON_SHOW_RESET_GAME_DIALOG);
		GameObject.Find ("ResetGameConfirmDialog").GetComponent<Dialog> ().Show (true);
	}

	public void ShowExitConfirmDialog ()
	{
		//Show banner advertisment
		AdsManager.instance.ShowAdvertisment (AdPackage.AdEvent.Event.ON_SHOW_EXIT_DIALOG);
		GameObject.Find ("ExitConfirmDialog").GetComponent<Dialog> ().Show (true);
	}

	public void PointerButtonEvent (Pointer pointer)
	{
		if (pointer == null) {
			return;
		}
		if (pointer.group != null) {
			ScrollSlider.instance.DisableCurrentPointer ();
			FindObjectOfType<ScrollSlider> ().currentGroupIndex = pointer.group.Index;
			ScrollSlider.instance.GoToCurrentGroup ();

		}
	}

	public void ResetGameConfirmDialogEvent (GameObject value)
	{
		if (value == null) {
			return;
		}

		if (value.name.Equals ("YesButton")) {
			Debug.Log ("Reset Game Confirm Dialog : No button clicked");
			DataManager.instance.ResetGameData ();
		} else if (value.name.Equals ("NoButton")) {
			Debug.Log ("Reset Game Confirm Dialog : No button clicked");
		}
		GameObject.Find ("ResetGameConfirmDialog").GetComponent<Dialog> ().Hide (true);
	}

	public void ExitConfirmDialogEvent (GameObject value)
	{
		if (value.name.Equals ("YesButton")) {
			Debug.Log ("Exit Confirm Dialog : Yes button clicked");
			Application.Quit ();
		} else if (value.name.Equals ("NoButton")) {
			Debug.Log ("Exit Confirm Dialog : No button clicked");
		}
		GameObject.Find ("ExitConfirmDialog").GetComponent<Dialog> ().Hide (true);
	}

	public void CloseNoConnectionDialog ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		GameManager.instance.isRunning = true;
		Timer.instance.Resume ();
		GameManager.instance.noConnectionDialog.Hide (false);
	}

	public void IncreaseTimeDialogEvent (GameObject value)
	{
		AudioClips.instance.PlayButtonClickSFX ();

		if (value.name.Equals ("YesButton")) {
			Debug.Log ("Increase Time Dialog : Yes button clicked");
			
			//???
//			InAppPurchasing.Purchase(EM_IAPConstants.Product_Ten_Times);

//original			Timer.instance.ResetIncCounter ();
//original			AdsManager.instance.ShowAdvertisment (AdPackage.AdEvent.Event.ON_INCREASE_TIME);
		} else if (value.name.Equals ("NoButton")) {
			Debug.Log ("Increase Time : No button clicked");
		}
		GameManager.instance.isRunning = true;
		Timer.instance.Resume ();
		GameManager.instance.increaseTimeDialog.Hide (false);
	}
	//???
/*	void OnEnable()
	{   
		Advertising.AdsRemoved += AdsRemovedHandler;         
		InAppPurchasing.PurchaseCompleted += PurchaseCompletedHandler;
		InAppPurchasing.PurchaseFailed += PurchaseFailedHandler;
	}
	void OnDisable()
	{            
		InAppPurchasing.PurchaseCompleted -= PurchaseCompletedHandler;
		InAppPurchasing.PurchaseFailed -= PurchaseFailedHandler;
	}
	void PurchaseCompletedHandler(IAPProduct product)
	{ 
		switch (product.Name)
		{
			case EM_IAPConstants.Product_Ten_Times:
				Timer.instance.ResetIncCounter ();
				break;		
		} 
	}
	void PurchaseFailedHandler(IAPProduct product)
	{
		Debug.Log("The purchase of product " + product.Name + " has failed.");
	}
	void AdsRemovedHandler()
	{
		Debug.Log("Ads were removed.");
		// Unsubscribe
		Advertising.AdsRemoved -= AdsRemovedHandler;
	}	
*/	
	
	
	

	public void MissionButtonEvent (Mission mission)
	{
		if (mission == null) {
			Debug.Log ("Mission event parameter is undefined");
			return;
		}

		Mission.selectedMission = mission;
		LoadLevelsScene ();
	}

	public void CloseLockedDialog ()
	{
		GameObject.Find ("LockedDialog").GetComponent<Dialog> ().Hide (true);
	}

	public void LevelButtonEvent (TableLevel tableLevel)
	{
		if (tableLevel == null) {
			Debug.Log ("TableLevel Event parameter is undefined");
			return;
		}
			
		if (tableLevel.isLocked) {
			AdsManager.instance.ShowAdvertisment (AdPackage.AdEvent.Event.ON_SHOW_LOCKED_DIALOG);
			GameObject.Find ("LockedDialog").GetComponent<Dialog> ().Show (true);
			return;
		}

		TableLevel.selectedLevel = tableLevel;
		LoadGameScene ();
	}

	public void OpenLink (string link)
	{
		AudioClips.instance.PlayButtonClickSFX ();

		if (string.IsNullOrEmpty (link)) {
			return;
		}
		Application.OpenURL (link);
	}

	public void GameNextButtonEvent ()
	{
		GameManager.instance.NextLevel ();
	}

	public void GameBackButtonEvent ()
	{
		GameManager.instance.PreviousLevel ();
	}

	public void PauseButtonEvent ()
	{
		GameManager.instance.Pause ();
	}

	public void ResumeGameButtonEvent ()
	{
		GameManager.instance.Resume ();
	}

	public void WinDialogNextButtonEvent ()
	{
		if (TableLevel.selectedLevel.ID == LevelsTable.levels.Count) {
			LoadLevelsScene ();
			return;
		}
		BlackArea.Hide ();
		WinDialog.instance.Hide ();
		GameManager.instance.NextLevel ();
	}

	public void TimeIncButtonEvent(){
		Timer.instance.IncreaseTime ();
	}

	public void LoadMainScene ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		StartCoroutine (SceneLoader.LoadSceneAsync ("Main"));
	}

	public void LoadHowToPlayScene ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		StartCoroutine (SceneLoader.LoadSceneAsync ("HowToPlay"));
	}

	public void LoadMissionsScene ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		StartCoroutine (SceneLoader.LoadSceneAsync ("Missions"));
	}

	public void LoadOptionsScene ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		StartCoroutine (SceneLoader.LoadSceneAsync ("Options"));
	}

	public void LoadAboutScene ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		StartCoroutine (SceneLoader.LoadSceneAsync ("About"));
	}

	public void LoadLevelsScene ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		StartCoroutine (SceneLoader.LoadSceneAsync ("Levels"));
	}

	public void LoadGameScene ()
	{
		AudioClips.instance.PlayButtonClickSFX ();
		StartCoroutine (SceneLoader.LoadSceneAsync ("Game"));
	}
}