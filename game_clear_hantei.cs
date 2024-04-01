using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_clear_hantei : MonoBehaviour
{
    public int point = 0;//現在の御札の枚数
    public string clear = "clear_scene";//クリアシーン
    public int goal = 6;//最終目標の枚数
    // Start is called before the first frame update
    void Start()
    {   
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (point == goal)
        {
            
            FadeManager.Instance.LoadScene(clear, 1.0f);
        }
    }
}
