using UnityEngine;
using System.Collections;

public class StartMenuGUI : MonoBehaviour {
    void OnGUI() {
        // Load GamePlay scene
        if (GUI.Button (new Rect (10,10,100,20), "Load game")) {
            Application.LoadLevel(1);
        }
    }
}
