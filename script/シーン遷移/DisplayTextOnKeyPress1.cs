using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class DisplayTextOnKeyPress1 : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public string[] fullTexts;
    public string[] fullTexts_en;
    private string[] fullTexts_show;
    private string currentText = "";
    private int currentIndex = 0;
    private int count = 0;
    private float textDisplaySpeed = 0.05f;
    private int numberOfElements;
    public string scene;
    private float timer = 0f;
    private AudioSource text_Audio;

    void Start()
    {
        numberOfElements = fullTexts.Length;
        GameObject targetObject1 = GameObject.Find("Canvas");
        text_Audio = targetObject1.GetComponent<AudioSource>();
        displayText.enabled = true;
        displayText.text = currentText;
        OnLanguageChanged();
        if (fullTexts_show == null) fullTexts_show = fullTexts;
    }

    void Update()
    {
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
            if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
            {
                if (numberOfElements - 1 <= count)
                {
                    displayText.enabled = false;
                    count = 0;
                    text_root();
                    FadeManager.Instance.LoadScene(scene, 1.0f);
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
