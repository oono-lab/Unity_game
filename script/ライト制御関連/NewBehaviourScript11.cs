using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript11 : MonoBehaviour
{
    public Light light_this;
    private float timer = 0f; // 時間計測用のタイマー
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            light_this.enabled = false;
            if ((timer >= 2.1))
            {
                light_this.enabled = true;
            }
            if ((timer >= 2.2))
            {
                light_this.enabled = false;
            }
            if ((timer >= 2.3))
            {
                light_this.enabled = true;
                timer = -1f;
            }
        }

    }
}
