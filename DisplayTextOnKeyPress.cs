using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine.Playables;

public class DisplayTextOnKeyPress : MonoBehaviour
{
    
    public PlayableDirector timelineDirector;
    public GameObject game_setumei_UI;//テキストを読み終えて表示する際のUI。元々UIを非表示に設定する必要がある
    public GameObject[] targetObjects;//テキスト表示中に付与されているスクリプトを全て無効にする
    public KeyCode displayKey = KeyCode.Space; // 表示キーとして設定するキーコード
    public TextMeshProUGUI displayText; // 表示するテキストUI
    public Outline outline; // アウトラインコンポーネント
    public string[] fullTexts; // 表示させるテキスト
    public int hantei = 0;
    private string currentText = ""; // 現在表示されているテキスト
    private int currentIndex = 0;
    private int count = 0;// 現在表示している文字のインデックス
    private float textDisplaySpeed = 0.05f; // テキストを表示する速度（秒）
    private int numberOfElements;
    private float timer = 0f; // 時間計測用のタイマー 
    public float targetTime = 0.0f;
    void Start()
    {
        numberOfElements = fullTexts.Length;
        displayText.enabled = false;
        displayText.text = currentText;
    }
    void Update()
    {
        // アウトラインが表示されていて、特定のキーが押されたら
            
            if ((outline.enabled == true && Input.GetKey(displayKey))||(hantei!=0))
            {
            
            
                script_hantei(false);
            
            

            
            if (hantei == 2)
            {if (timelineDirector.time >= targetTime)
                {
                    displayText.enabled = true;
                    timelineDirector.Pause();
                }
                  
            }else
            {
                displayText.enabled = true;
            }
                
            }
            if (displayText.enabled == true)
            {
            if (currentIndex < fullTexts[count].Length)
            {   
                timer += Time.deltaTime; // タイマーを更新

                // 指定した速度以上の時間が経過したら次の文字を表示する
                if (timer >= textDisplaySpeed)
                {
                    currentText += fullTexts[count][currentIndex]; // 次の文字を追加
                    displayText.text = currentText; // テキストを更新
                    currentIndex++; // インデックスを増やす
                    timer = 0f; // タイマーをリセット
                }
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                
                if (numberOfElements-1 <= count)
                {
                    
                    
                    count = 0;
                    text_root();
                    if (game_setumei_UI ==　null)
                    {
                        script_hantei(true);
                    }
                    else
                    {
                       
                        game_setumei_UI.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                    }
                    
                    displayText.enabled = false;
                    if (hantei == 2)
                    {
                        timelineDirector.Play();
                    }
                    hantei = 0;

                }
                else
                {
                    count++;
                    text_root();
                }
                
            }
        }
        

            
        }
    void text_root()
    {
        currentText = "";
        currentIndex = 0;
    }
    public void script_hantei(bool hantei)
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
    }

