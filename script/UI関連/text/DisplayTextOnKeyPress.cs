using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine.Playables;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
public class DisplayTextOnKeyPress : MonoBehaviour
{
    
    public PlayableDirector timelineDirector;
    public GameObject game_setumei_UI;
    public GameObject[] targetObjects;
    public KeyCode displayKey = KeyCode.Space;
    public TextMeshProUGUI displayText;
    public Outline outline;
    public string[] fullTexts;
    public string[] fullTexts_en;
    private string[] fullTexts_show;
    public int hantei = 0;
    public bool run_hantei = false;
    private string currentText = "";
    private int currentIndex = 0;
    private int count = 0;
    private float textDisplaySpeed = 0.05f;
    private int numberOfElements;
    private Move sound_hantei;
    private float timer = 0f;
    public float targetTime = 0.0f;
    private AudioSource text_Audio;
    private AudioSource input_key_audio;
    void Start()
    {
        GameObject targetObject1 = GameObject.Find("Canvas");
        text_Audio = targetObject1.GetComponent<AudioSource>();
        GameObject targetObject2 = GameObject.Find("Cube");
        input_key_audio = targetObject2.GetComponent<AudioSource>();
        GameObject targetObject = GameObject.Find("Main Camera");
        sound_hantei = targetObject.GetComponent<Move>();
        numberOfElements = fullTexts.Length;
        displayText.enabled = false;
        displayText.text = currentText;

        
        if (fullTexts_show == null) fullTexts_show = fullTexts;

    }
    void Update()
    {
        
        OnLanguageChanged();
        if ((outline.enabled == true && Input.GetKey(displayKey))||(hantei!=0))
        {
            if (hantei == 0)
            {
                sound_hantei.StopAudio();
                if (displayText.enabled == false) if(input_key_audio!=null) input_key_audio.Play();
            }
            if (hantei == 2)
            {
                if (timelineDirector.time >= targetTime)
                {
                    displayText.enabled = true;
                    timelineDirector.Pause();
                }
                  
            }else
            {     
                displayText.enabled = true;
            }
            


            script_hantei(false);
        }
            if (displayText.enabled == true)
            {
            if (currentIndex < fullTexts_show[count].Length)
            {   
                timer += Time.deltaTime;

            
                if (timer >= textDisplaySpeed)
                {
                    currentText += fullTexts_show[count][currentIndex];
                    displayText.text = currentText;
                    currentIndex++;
                    timer = 0f;
                    
                }
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                
                if (numberOfElements-1 <= count)
                {
                    
                    
                    count = 0;
                    text_root();
                    if (game_setumei_UI ==null)
                    {
                        script_hantei(true);
                    }
                    else
                    {
                        
                        game_setumei_UI.SetActive(true);
                        Cursor.visible = true;
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
                text_Audio.Play();
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
    void OnLanguageChanged()
    {
        if (LanguageManager.SelectedLanguage == 0) OnLanguageChanged_jp();
        else OnLanguageChanged_en();
    }
    void OnLanguageChanged_jp()
    {
        fullTexts_show = fullTexts;
        textDisplaySpeed = 0.05f;
    }
    void OnLanguageChanged_en()
    {
        fullTexts_show = fullTexts_en;
        textDisplaySpeed = 0.03f;
    }
}

