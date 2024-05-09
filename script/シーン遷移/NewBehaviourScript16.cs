using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript16 : MonoBehaviour
{
    public string scene;
    public GameObject[] targetObjects; 
    public Outline outline;
    private Move sound_hantei;
    // Start is called before the first frame update

    void Start()
    {
        GameObject targetObject = GameObject.Find("Main Camera");
        sound_hantei = targetObject.GetComponent<Move>();
    }
    // Update is called once per frame
    void Update()
    {   if ((outline.enabled == true && Input.GetKey(KeyCode.E))){
            sound_hantei.StopAudio();
            script_hantei(false);
            FadeManager.Instance.LoadScene(scene, 1.0f);
        }
        
    }
    void script_hantei(bool hantei)
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
