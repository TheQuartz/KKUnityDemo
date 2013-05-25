using UnityEngine;
using System.Collections;

public class InGameMenuGUI : MonoBehaviour {
    private static int[] LEVEL_POINTS = {0, 10, 30, 80, 200, 500};
    public enum States {ONGAMING, ENDED};
    bool on = false;
    States state_;
    int points_;
    string got_quartz_;
    void Start() {
        state_ = States.ONGAMING;
        points_ = 0;
        got_quartz_ = "Quartz you've got:\n";
    }
    void OnGUI () {
        // Draw the menu
        // Restart game
        if (GUI.Button (new Rect(10, 10, 100, 20), "Restart game")) {
            Application.LoadLevel(1);
        }
        // Quit the current game and get back to the start menu
        if (GUI.Button (new Rect (10,40,100,20), "End game")) {
            if (state_ == States.ONGAMING) {
            
                foreach (GameObject a in GameObject.FindGameObjectsWithTag("quartz")) {
                    Quartz quartz_script = a.GetComponent<Quartz>();
                    int level = quartz_script.GetLevel();
                    // Do NOT count the prefab
                    if (level > 0) {
                        Quartz.Colors color = quartz_script.GetColor();
                        points_ += LEVEL_POINTS[level];
                        got_quartz_ += "Level "+level+" "+color.ToString()+"\n";
                        Destroy(a);
                    }
                    
                }
                state_ = States.ENDED;
            }
        }
        if (GUI.Button (new Rect(10, 70, 100, 20), "Quit")) {
            Application.LoadLevel(0);
        }
        if (state_ == States.ENDED) {
            string table_head;
            GUI.TextArea(
                new Rect(200, 100, 500, 500),
                got_quartz_+"\nYou've Got "+points_.ToString()+" points");
        }
        
    }
    void Toggle() {
        on = !on;
    }
}
