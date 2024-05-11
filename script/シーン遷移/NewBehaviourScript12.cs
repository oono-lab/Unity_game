using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript12 : MonoBehaviour
{
    public string scene;
    public bool Button_crick_hantei = false;
    public float fade_speed = 1.0f;
    public GameObject[] gameObjects;
    private AudioSource button_crick;
    void Start()
    {
        GameObject targetObject1 = this.gameObject;
        button_crick = targetObject1.GetComponent<AudioSource>();
        
    }
    public void OnClickStartButton()
    {
        if (Button_crick_hantei == true) {
            PlayAudio();
            if (gameObjects[0] != null) script_hantei(false);
        }  

        FadeManager.Instance.LoadScene(scene, fade_speed);
    }
    public void OnClickStartButton_not_fade_out()
    {
        SceneManager.LoadScene(scene);
    }
    public void OnClickStartButton_Quit()
    {
        if (Button_crick_hantei == true) Application.Quit();
    }
    void PlayAudio()
    {
        Button_crick_hantei = false;
        if (!button_crick.isPlaying) button_crick.Play();
    }
    void script_hantei(bool hantei)
    {
        foreach (GameObject obj in gameObjects)
        {
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts) script.enabled = hantei; 
        }
    }
}
