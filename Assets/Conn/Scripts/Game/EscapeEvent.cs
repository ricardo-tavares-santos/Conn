using UnityEngine;
using System.Collections;

///Developed By Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

/// Escape or Back event
public class EscapeEvent : MonoBehaviour
{
	/// <summary>
	/// The name of the scene to be loaded.
	/// </summary>
	public string eventCallBack;

	/// <summary>
	/// Whether to leave the application on escape click.
	/// </summary>
	public bool leaveTheApplication;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			OnEscapeClick ();
		}
	}

	/// <summary>
	/// On Escape click event.
	/// </summary>
	public void OnEscapeClick ()
	{
		bool visibleDialogFound = HideVisibleDialogs ();
		if (visibleDialogFound) {
			return;
		}

		if (leaveTheApplication) {
			GameObject exitConfirmDialog = GameObject.Find ("ExitConfirmDialog");
			if (exitConfirmDialog != null) {
				Dialog exitDialogComponent = exitConfirmDialog.GetComponent<Dialog> ();
				if (!exitDialogComponent.animator.GetBool ("On")) {
					exitDialogComponent.Show (true);
					AdsManager.instance.ShowAdvertisment (AdPackage.AdEvent.Event.ON_SHOW_EXIT_DIALOG);
				}
			}
		} else {
			if (!string.IsNullOrEmpty (eventCallBack)) {
				UIEvents.instance.SendMessage (eventCallBack);
			}
		}
	}

	/// <summary>
	/// Hide the visible dialogs.
	/// </summary>
	/// <returns><c>true</c>, if visible dialogs was visible, <c>false</c> otherwise.</returns>
	private bool HideVisibleDialogs ()
	{
		bool visibleDialogFound = false;
	
		Dialog[] dialogs = GameObject.FindObjectsOfType<Dialog> ();
		if (dialogs != null) {
			foreach (Dialog d in dialogs) {
				if (d.visible) {
					if (d.name == "PauseDialog") {
						GameManager.instance.Resume ();
					} else {
						d.Hide (true);
					}
					visibleDialogFound = true;
				}
			}
		}
		return visibleDialogFound;
	}
}