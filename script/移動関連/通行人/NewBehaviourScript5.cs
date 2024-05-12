using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript5 : MonoBehaviour
{
    // Start is called before the first frame update
    private float lastZ; // 前回のz軸の値
    private float timer; // 経過時間
    public float thresholdZ = 1.0f;
    public float thresholdZ1 = 1.0f;
    public GameObject object1;
    void Start()
    {
        // 初期化

        lastZ = transform.position.z;
        timer = 0f;
        
        // 一定のz座標の閾値

    }

void Update()
    {
        // z軸の値が1の位が変化しなかった場合
        if (Mathf.FloorToInt(transform.position.z) % 10 == Mathf.FloorToInt(lastZ) % 10)
        {
            // 経過時間を加算
            timer += Time.deltaTime;
            // 経過時間が5秒以上経過した場合
            if (timer >= 5.0f) Destroy(gameObject);  
        }
        else timer = 0f; // z軸の値が変化した場合は経過時間をリセット
        // 現在のz軸の値を更新
        lastZ = transform.position.z;
        if ((lastZ > thresholdZ1) || (lastZ < thresholdZ)) Destroy(gameObject);
    }
}
