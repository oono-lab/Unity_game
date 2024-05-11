using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_text : MonoBehaviour
{
    public TextMeshProUGUI score_text;
    private game_clear_hantei current_pt;
    private string GameObject_name = "Main Camera";
    // Start is called before the first frame update
    void Start()
    {
        GameObject targetObject = GameObject.Find(GameObject_name);
        current_pt = targetObject.GetComponent<game_clear_hantei>();
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = ": " + current_pt.point.ToString() + " / " + current_pt.goal.ToString();
    }
}
