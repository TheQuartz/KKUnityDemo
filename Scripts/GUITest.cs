using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	void OnGUI () {
		// This line feeds "This is the tooltip" into GUI.tooltip
		if (GUI.Button (new Rect (10,10,100,20), "Load game")) {
			Application.LoadLevel(1);
		}
	}
}
