using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class NewBehaviourScript10 : MonoBehaviour
{
    public GameObject[] targetObjects; // 対象のオブジェクトの配列
    public TextMeshProUGUI displayText;
    private string fullText="ここからさきには蕎麦屋はなさそうだ。";
    private string fullText_en = "There does not seem to be any buckwheat noodle shops beyond this point.";
    private string fullTexts_show;
    private string currentText = "";
    private int currentIndex = 0;
    private Move sound_hantei;
    private AudioSource text_Audio;
    private float textDisplaySpeed = 0.05f; // テキストを表示する速度（秒）
    private float timer = 0f; // 時間計測用のタイマー
    void Start()
    {
        GameObject targetObject1 = GameObject.Find("Canvas");
        text_Audio = targetObject1.GetComponent<AudioSource>();
        GameObject targetObject = GameObject.Find("Main Camera");
        sound_hantei = targetObject.GetComponent<Move>();
        displayText.enabled = false;
        displayText.text = currentText;
        
    }
    void Update()
    {
        OnLanguageChanged();
        Vector3 tmp = targetObjects[0].transform.position;
        if (tmp.z>=30 || tmp.z<=-20)
        {
            sound_hantei.StopAudio();
            script_hantei1(false);
            displayText.enabled = true;
            // 複数のオブジェクトにアタッチされた特定のスクリプトを無効にする
         
        }
        if(displayText.enabled == true)
        {
            if (currentIndex < fullTexts_show.Length)
            {
                timer += Time.deltaTime; // タイマーを更新

                // 指定した速度以上の時間が経過したら次の文字を表示する
                if (timer >= textDisplaySpeed)
                {
                    currentText += fullTexts_show[currentIndex]; // 次の文字を追加
                    displayText.text = currentText; // テキストを更新
                    currentIndex++; // インデックスを増やす
                    timer = 0f; // タイマーをリセット
                }

            }
            if (Input.GetMouseButtonDown(0))
            {

                
                if(tmp.z >= 30)
                {
                    targetObjects[0].transform.position = new Vector3(tmp.x, tmp.y, tmp.z - 1);
                }
                else
                {
                    targetObjects[0].transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 1);
                }
                text_Audio.Play();
                text_root1();
                displayText.enabled = false;
                script_hantei1(true);
                

                
                

            }
        }
    }
    void script_hantei1(bool hantei)
    {
        foreach (GameObject obj in targetObjects)
        {
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = hantei;
            }
        }
    }
    void text_root1()
    {
        fullTexts_show = "";
        currentText = "";
        currentIndex = 0;
    }
    void OnLanguageChanged()
    {
        if (LanguageManager.SelectedLanguage == 0) OnLanguageChanged_jp();
        else OnLanguageChanged_en();
    }
    void OnLanguageChanged_jp()
    {
        fullTexts_show = fullText;
        textDisplaySpeed = 0.05f;
    }
    void OnLanguageChanged_en()
    {
        fullTexts_show = fullText_en;
        textDisplaySpeed = 0.03f;
    }


}
