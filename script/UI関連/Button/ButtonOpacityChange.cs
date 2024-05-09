using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOpacityChange : MonoBehaviour
{
    public Button button;
    private Color normalColor;
    public Color highlightedColor; // ìßñæìxÇïœÇ¶ÇÈç€ÇÃêF
    private AudioSource enter_sound;
    void Start()
    {
        GameObject targetObject = GameObject.Find("enter_sound");
        enter_sound = targetObject.GetComponent<AudioSource>();
        normalColor = button.image.color;
    }

    public void OnPointerEnter()
    {   if (enter_sound != null) enter_sound.Play();
        else Debug.Log("NOT Sound");
        button.image.color = highlightedColor;
    }

    public void OnPointerExit()
    {
        button.image.color = normalColor;     
    }
}
