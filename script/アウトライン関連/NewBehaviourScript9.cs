using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NewBehaviourScript9 : MonoBehaviour
{
    public Outline outline; // アウトラインを表示するためのコンポーネント

    private void Start()
    {
        outline.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // 衝突したオブジェクトが特定のタグを持っている場合に処理を行う
        if (other.CompareTag("TargetTag"))
        {
            outline.enabled = true;
            // アウトラインを非表示にする

        }
    }

    void OnTriggerExit(Collider other)
    {
        // 衝突していたオブジェクトが離れた場合に処理を行う
        if (other.CompareTag("TargetTag"))
        {
            outline.enabled = false;
            // アウトラインを再び表示する
            
        }
    }
}
