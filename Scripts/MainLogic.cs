using UnityEngine;
using System.Collections;


public class MainLogic : MonoBehaviour {
    private static int QUARTZ_NUMBER = 16;
    private static int QUARTZ_PER_ROW = 4;
    private static Quartz.Colors[] colors = {
        Quartz.Colors.RED, Quartz.Colors.BLUE, Quartz.Colors.YELLOW};
    
    Object quartz_prefab_;
    GameObject last_quartz_;
    // Use this for initialization
    IEnumerator Start () {
        last_quartz_ = null;
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
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameObject.Find("Menu").SendMessage("Toggle");
        }
    }
    
    IEnumerator  OnCheckQuartz(GameObject quartz) {
        if (last_quartz_ == null) {
            last_quartz_ = quartz;
        } else {
            Quartz last_quartz_script = last_quartz_.GetComponent<Quartz>();
            Quartz quartz_script = quartz.GetComponent<Quartz>();
            print (last_quartz_script.GetLevel ());
            print (quartz_script.GetLevel ());
            if (last_quartz_script.GetLevel() != quartz_script.GetLevel()) {
                // level doesn't match, destory the two quartz
                Destroy(last_quartz_);
                Destroy(quartz); 
            } else {
                // TODO: use animation to replace the wait
                yield return new WaitForSeconds(0.5f);
                Vector3 new_position = last_quartz_.transform.position;
                
                
                Quartz.Colors last_color = last_quartz_script.GetColor();
                Quartz.Colors color = quartz_script.GetColor();
                
                int new_level = last_quartz_script.GetLevel();
                Destroy(last_quartz_);
                Destroy(quartz);
                Quartz new_quartz_script = ((GameObject)Instantiate(
                    quartz_prefab_,
                    new_position,
                    Quaternion.identity)).GetComponent<Quartz>();
                if (last_color == color) {
                    new_quartz_script.SetColor(last_color);
                    new_quartz_script.SetLevel(new_level+1);
                } else if (last_color != Quartz.Colors.BLUE &&
                           color != Quartz.Colors.BLUE) {
                    new_quartz_script.SetColor(Quartz.Colors.BLUE);
                    new_quartz_script.SetLevel(new_level);
                } else if (last_color != Quartz.Colors.YELLOW &&
                           color != Quartz.Colors.YELLOW) {
                    new_quartz_script.SetColor(Quartz.Colors.YELLOW);
                    new_quartz_script.SetLevel(new_level);
                } else if (last_color != Quartz.Colors.RED &&
                           color != Quartz.Colors.RED) {
                    new_quartz_script.SetColor(Quartz.Colors.RED);
                    new_quartz_script.SetLevel(new_level);
                }
                
                new_quartz_script.Toggle();
                // TODO: use animation to replace the wait
                yield return new WaitForSeconds(0.5f);
                new_quartz_script.Toggle();
            }
            
            last_quartz_ = null;
        }
    }
}
