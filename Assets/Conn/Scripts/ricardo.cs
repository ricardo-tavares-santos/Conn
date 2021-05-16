using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//???
using EasyMobile;

public class ricardo : MonoBehaviour {
	
	public static ricardo instance;
	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}
	
	
	public void OpenRWURL() {
		Application.OpenURL("https://play.google.com/store/apps/dev?id=...");
	}
	
	public void OpenStarURL() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=...");
	}
	
	string subject = "Conn! Maze Puzzle";
	string body = "Conn! Maze Puzzle:  https://play.google.com/store/apps/details?id=...";	 
	public void shareText(){
		//execute the below lines if being run on a Android device
		#if UNITY_ANDROID
			  //Refernece of AndroidJavaClass class for intent
			  AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
			  //Refernece of AndroidJavaObject class for intent
			  AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
			  //call setAction method of the Intent object created
			  intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			  //set the type of sharing that is happening
			  intentObject.Call<AndroidJavaObject>("setType", "text/plain");
			  //add data to be passed to the other activity i.e., the data to be sent
			  intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
			  intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
			  //get the current activity
			  AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			  AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			  //start the activity by sending the intent data
			  currentActivity.Call ("startActivity", intentObject);
		#endif
	}		
	

	public void abrirLeaderboard() {
		#if UNITY_ANDROID
		if (GameServices.IsInitialized()) {
			GameServices.ShowLeaderboardUI();
		} else {
			GameServices.Init();
			GameServices.ShowLeaderboardUI();
		} 
		#endif
	}	
	
	
	public void BuyNoAdsBt(){ 
		InAppPurchasing.Purchase(EM_IAPConstants.Product_No_Ads);
	}
	public void BuyTimeBt(){ 
		InAppPurchasing.Purchase(EM_IAPConstants.Product_Ten_Times);
	}	
	
	
	void OnEnable()
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
			case EM_IAPConstants.Product_No_Ads:				
				Advertising.RemoveAds();			
				break;
			case EM_IAPConstants.Product_Ten_Times:
				Timer.instance.ResetIncCounter ();
				
				GameManager.instance.isRunning = true;
				Timer.instance.Resume ();
				GameManager.instance.increaseTimeDialog.Hide (false);	
				
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


	
}
