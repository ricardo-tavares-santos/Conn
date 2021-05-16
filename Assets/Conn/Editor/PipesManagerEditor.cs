using UnityEngine;
using System.Collections;
using UnityEditor;

///Developed By Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

[CustomEditor(typeof(PipesManager))]
public class PipesManagerEditor : Editor
{
	private bool windowVisible;

	public override void OnInspectorGUI ()
	{
		PipesManager attrib = (PipesManager)target;//get the target

		EditorGUILayout.Separator ();
		EditorGUILayout.HelpBox ("Click on 'Manage Pipes' to manage the pipes of the game", MessageType.Info);

		GUI.backgroundColor = Colors.greenColor;
		if (GUILayout.Button ("Manage Pipes", GUILayout.Width (150), GUILayout.Height (22))) {
			PipesManagerWindow.Init();
		}
		EditorGUILayout.Separator ();

		GUI.backgroundColor = Colors.whiteColor;
		if (!windowVisible) {
			windowVisible = true;
			PipesManagerWindow.Init();
		}
		if (GUI.changed) {
			DirtyUtil.MarkSceneDirty ();
		}
	}
}
