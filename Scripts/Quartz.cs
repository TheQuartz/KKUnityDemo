using UnityEngine;
using System.Collections;

public class Quartz : MonoBehaviour {
    public enum Colors {RED=1, YELLOW, BLUE};
    private int level_;
    private Colors color_;
    private bool open_ = false;
    private GameObject main_logic_;
    // Use this for initialization
	void Start () {
        // open_ = false;
        main_logic_ = GameObject.Find("MainLogic");
    }
    // Set/Get quartz's level
    public void SetLevel(int level) {
        level_ = level;
    }
    public int GetLevel() {
        return level_;
    }
    // Set/Get quartz's color
    public void SetColor(Colors color) {
        color_ = color;
    }
    public Colors GetColor() {
        return color_;
    }
    // Open/Unopen quartz
    public void Toggle() {
        open_ = !open_;
    }
    void OnGUI() {
        Vector3 world_position = transform.position;
        Vector3 position = Camera.main.WorldToScreenPoint(world_position);
        float x = position.x-30;
        float y = Screen.height-position.y;
        if (open_) {
            GUI.Label(new Rect(x, y, 100, 50),
                       level_.ToString()+" "+color_.ToString());
        } else {
            GUI.Label(new Rect(x, y, 100, 50),
                      "Unopen");
        }
    }
    
	void Update () {
    }
    void OnMouseUp() {
        if (!open_) {
            main_logic_.SendMessage("OnCheckQuartz", gameObject);
        }
    }
}
