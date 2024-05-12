using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{

    public Transform target; // 音量を調整したいターゲットオブジェクト
    private AudioSource audioSource;
    public float maxDistance = 10f; // 最大距離// Start is called before the first frame update
    void Start()
    {
        GameObject oni = this.gameObject;
        audioSource= oni.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector3.Distance(transform.position, target.position);
        // 最大距離内の場合
        if (distance <= maxDistance)
        {
            // 距離に応じて音量を調整
            float volume = 1f - (distance / maxDistance); // 最大距離に対する割合
            audioSource.volume = volume;
        }
        else
        {
            // 最大距離を超えた場合は音量を0にする
            audioSource.volume = 0f;
        }
    }
}
