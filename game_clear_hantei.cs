using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_clear_hantei : MonoBehaviour
{
    public int point = 0;//���݂̌�D�̖���
    public string clear = "clear_scene";//�N���A�V�[��
    public int goal = 6;//�ŏI�ڕW�̖���
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
