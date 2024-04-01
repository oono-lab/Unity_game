using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ohuda_pt : MonoBehaviour
{
    private game_clear_hantei current_pt;
    private KeyCode displayKey = KeyCode.E;//ユーザー側の操作キー
    private GameObject this_obj;//アタッチされているオブジェクトを非表示
    private Outline outline;//アタッチされているゲームオブジェクトのアウトライン
    private string GameObject_name= "Main Camera";//game_clear_hanteiにアタッチされているオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        GameObject targetObject = GameObject.Find(GameObject_name);
        current_pt = targetObject.GetComponent<game_clear_hantei>();
        this_obj = this.gameObject;
        outline = this.GetComponent<Outline>();
        current_pt.point = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if ((outline.enabled == true && Input.GetKey(displayKey))){
            
            this_obj.SetActive(false);
            current_pt.point += 1;
            //Debug.Log(current_pt.point);

        }
        
    }
}
