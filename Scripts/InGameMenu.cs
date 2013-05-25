using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {
    bool on = false;
    void OnGUI () {
        // Draw the menu
        if (on) {
            // Quit the current game and get back to the start menu
            if (GUI.Button (new Rect (10,10,100,20), "Quit")) {
                Application.LoadLevel(0);
            }
        }
    }
    void Toggle() {
        on = !on;
    }
}
