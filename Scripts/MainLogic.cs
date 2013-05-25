using UnityEngine;
using System.Collections;


public class MainLogic : MonoBehaviour {
    private static int QUARTZ_NUMBER = 16;
    private static int QUARTZ_PER_ROW = 4;
    private static Quartz.Colors[] colors = {
        Quartz.Colors.RED, Quartz.Colors.BLUE, Quartz.Colors.YELLOW};
    
    Object quartz_prefab_;
    GameObject first_quartz_;
    GameObject second_quartz_;
    // Use this for initialization
    IEnumerator Start () {
        first_quartz_ = null;
        second_quartz_ = null;
        quartz_prefab_ = GameObject.Find("Quartz");
        System.Random random = new System.Random();
        Quartz[] quartz_array = new Quartz[QUARTZ_NUMBER];
        for (int i = 0; i < QUARTZ_NUMBER; ++i) {
            Quartz new_quartz_script = ((GameObject) Instantiate(
                quartz_prefab_,
                new Vector3(i%QUARTZ_PER_ROW*2.5f-4.0f,
                            i/QUARTZ_PER_ROW*2.5f-4.0f,
                            0),
                Quaternion.identity)).GetComponent<Quartz>();
            quartz_array[i] = new_quartz_script;
            new_quartz_script.SetLevel(1);
            

            new_quartz_script.SetColor(colors[random.Next(0,3)]);
            new_quartz_script.Toggle();
        }
        // TODO: use animation or other better way to replace wait.
        yield return new WaitForSeconds(5);
        for (int i = 0; i < QUARTZ_NUMBER; ++i) {
            quartz_array[i].Toggle();
        }
    }
	
    void Update () {
    }
    
    IEnumerator  OnCheckQuartz(GameObject quartz) {
        if (first_quartz_ == null) {
            first_quartz_ = quartz;
            first_quartz_.SendMessage("Toggle");
        } else if (second_quartz_ == null) {
            second_quartz_ = quartz;
            second_quartz_.SendMessage("Toggle");
            Quartz first_quartz_script = first_quartz_.GetComponent<Quartz>();
            Quartz second_quartz_script = second_quartz_.GetComponent<Quartz>();
            
            int first_quartz_level = first_quartz_script.GetLevel();
            int second_quartz_level = second_quartz_script.GetLevel();
            if (first_quartz_level != second_quartz_level) {
                // level doesn't match, destory the two quartz
                Destroy(first_quartz_);
                Destroy(second_quartz_); 
            } else {
                // TODO: use animation to replace the wait
                yield return new WaitForSeconds(0.5f);
                Vector3 new_position = first_quartz_.transform.position;
                
                
                Quartz.Colors first_color = first_quartz_script.GetColor();
                Quartz.Colors second_color = second_quartz_script.GetColor();
                
                int new_level = first_quartz_level;
                Destroy(first_quartz_);
                Destroy(second_quartz_);
                first_quartz_ = null;
                second_quartz_ = null; 
                Quartz new_quartz_script = ((GameObject)Instantiate(
                    quartz_prefab_,
                    new_position,
                    Quaternion.identity)).GetComponent<Quartz>();
                if (first_color == second_color) {
                    new_quartz_script.SetColor(first_color);
                    new_quartz_script.SetLevel(new_level+1);
                } else if (first_color != Quartz.Colors.BLUE &&
                           second_color != Quartz.Colors.BLUE) {
                    new_quartz_script.SetColor(Quartz.Colors.BLUE);
                    new_quartz_script.SetLevel(new_level);
                } else if (first_color != Quartz.Colors.YELLOW &&
                           second_color != Quartz.Colors.YELLOW) {
                    new_quartz_script.SetColor(Quartz.Colors.YELLOW);
                    new_quartz_script.SetLevel(new_level);
                } else if (first_color != Quartz.Colors.RED &&
                           second_color != Quartz.Colors.RED) {
                    new_quartz_script.SetColor(Quartz.Colors.RED);
                    new_quartz_script.SetLevel(new_level);
                }
                
                new_quartz_script.Toggle();
                // TODO: use animation to replace the wait
                yield return new WaitForSeconds(0.5f);
                new_quartz_script.Toggle();
            }
            
        } else {
            print ("You shoud not open a box with two boxes already opened");
        }
    }
}
