using UnityEngine;
using System.Collections;


public class MainLogic : MonoBehaviour {
    GameObject menu;
    // Use this for initialization
    void Start () {	
    }
	
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameObject.Find("Menu").SendMessage("Toggle");
        }
    }
}
