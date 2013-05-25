using UnityEngine;
using System.Collections;

public class InGameMenuGUI : MonoBehaviour {
    private static int[] LEVEL_POINTS = {0, 10, 30, 80, 200, 500};
    public enum States {ONGAMING, ENDED};
    bool on = false;
    States state_;
    int points_;
    
    void OnStart() {
        state_ = States.ONGAMING;
        points_ = 0;
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
                    Quartz.Colors color = quartz_script.GetColor();
                    points_ += LEVEL_POINTS[level];
                    print ("Level: "+level.ToString());
                    print ("Add "+LEVEL_POINTS[level].ToString());
                    Destroy(a);
                }
                state_ = States.ENDED;
            }
        }
        if (GUI.Button (new Rect(10, 70, 100, 20), "Quit")) {
            Application.LoadLevel(0);
        }
        if (state_ == States.ENDED) {
            GUI.TextArea(new Rect(200, 100, 500, 100),
                         "You've Got "+points_.ToString()+" points");
        }
        
    }
    void Toggle() {
        on = !on;
    }
}
