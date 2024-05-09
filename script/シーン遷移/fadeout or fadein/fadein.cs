using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour
{
    public string scene;
    public int hantei = 0;
    public float fade_speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.Instance.Load(scene, fade_speed, hantei);
    }

    // Update is called once per frame
    void Update()
    {   if (hantei == 0)
        {
            FadeManager.Instance.Load(scene, fade_speed, hantei);
        }
        else
        {
            return;
        }
        
    }
}
