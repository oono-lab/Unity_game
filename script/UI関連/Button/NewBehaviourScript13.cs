using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class NewBehaviourScript13 : MonoBehaviour
{
    public GameObject Ui;
    public GameObject Ui_game_setumei;
    public GameObject canvas;
    public GameObject[] targetObjects;
    public GameObject[] return_button_canvas;
    public Button[] UiObjects;
    public Button[] button;
    public AudioSource Audio;
    private AudioSource Audio_crick;
    private AudioSource Audio_crick_cancel;
    public int hantei = 0;
    private Color normalColor;
    public int point = 0;
    void Start()
    {
        GameObject targetObject1 = this.gameObject;
        Audio_crick = targetObject1.GetComponent<AudioSource>();
        GameObject targetObject = GameObject.Find("ƒLƒƒƒ“ƒZƒ‹");
        Audio_crick_cancel = targetObject.GetComponent<AudioSource>();
        button_active1(false);
        Ui.SetActive(false);
        normalColor = button[0].image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Escape)&&point==0))
        {
            
            
            button_active(true);
            Ui.SetActive(true);
            point = 1;
            script_hantei(false);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Audio_hantei(false);

        }
    }
    public void crick_escape()
    {
        
        button_active(false);
        button[0].image.color = normalColor;
        point = 0;
        if(hantei!=3) script_hantei(true);
        
        
        Ui.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Audio_hantei(true);
        Audio_crick.Play();
    }

    public void crick_setumei()
    {
        crick_syestem(0);
    }
    public void crick_setting()
    {
        crick_syestem(1);


    }
    public void crick_title()
    {
        hantei = 3;
        crick_escape();
        Cursor.lockState = CursorLockMode.None;
        FadeManager.Instance.LoadScene("title 1", 1.0f);

    }
    public void game_setumei()
    {       
            crick_syestem(2);

    }
    public void crick_return()
    {
        return_syestem(0);
    }
    public void crick_return1()
    {
        return_syestem(1);
    }
    public void crick_return2()
    {
        
        if (hantei == 1)
        {
            Cursor.visible = true;
            DisplayTextOnKeyPress targetScript = canvas.GetComponent<DisplayTextOnKeyPress>();
            targetScript.script_hantei(true);
            crick_escape();
            hantei = 0;
            Ui_game_setumei.SetActive(false);
            
        }
        else
        {
            return_syestem(2);
        }
    }
   public void script_hantei(bool hantei)
    {
        foreach (GameObject obj in targetObjects)
        {
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts) script.enabled = hantei;
        }
    }

    void button_active(bool hantei)
    {                  
        foreach (Button button in button) button.gameObject.SetActive(hantei);

    }
    void button_active1(bool hantei)
    {
        foreach (GameObject canvas in return_button_canvas) canvas.SetActive(hantei);
    }
    void return_syestem(int pt)
    {
        if (hantei == 2) Ui_game_setumei.SetActive(true);
        Audio_crick_cancel.Play();
        point = 0;
        return_button_canvas[pt].SetActive(false);
        button_active(true);
        UiObjects[pt].image.color = normalColor;
    }
    void crick_syestem(int pt)
    {   if (hantei == 2) Ui_game_setumei.SetActive(false);
        Audio_crick.Play();
        button_active(false);
        return_button_canvas[pt].SetActive(true);
        button[pt+1].image.color = normalColor;
    }
    void Audio_hantei(bool hantei)
    {
        if (Audio == null)
        {
            return;
        }
        else
        {
            if (hantei == true) Audio.Play();
            else Audio.Stop();
        }
    }
}
