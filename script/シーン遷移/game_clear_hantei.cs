using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_clear_hantei : MonoBehaviour
{
    public int point = 0;//���݂̌�D�̖���
    public string clear = "clear_scene";//�N���A�V�[��
    public Boolean clear_hantei = false;
    public int goal = 6;//�ŏI�ڕW�̖���
    public AudioSource asioto;
    // Start is called before the first frame update
    void Start()
    {   
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (point == goal)
        {   if (asioto != null) asioto.Stop();
            clear_hantei = true;
            FadeManager.Instance.LoadScene(clear, 2.0f);
        }
    }
}
