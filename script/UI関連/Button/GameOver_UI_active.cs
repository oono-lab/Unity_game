using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_UI_active : MonoBehaviour
{
    private FadeManager fade_hantei;
    public GameObject[] button_UI;
    // Start is called before the first frame update

    void Start()
    {
        GameObject targetObject = GameObject.Find("FadeManager");
        fade_hantei = targetObject.GetComponent<FadeManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (fade_hantei.isFading == false) foreach (GameObject button in button_UI) button.SetActive(true);
    }
}
