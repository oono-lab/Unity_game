using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse_move : MonoBehaviour
{
    float yRot;
    float xRot;
    float maxVerticalAngle = 40f; 
    float minVerticalAngle = -40f;
    public UnityEngine.UI.Scrollbar scrollbar;
    public string variableKey = "ScrollbarValue";
    private GameObject player;
    private GameObject this_obj;
    // Start is called before the first frame update
    void Start()
    {   
        if (PlayerPrefs.HasKey(variableKey)) scrollbar.value = PlayerPrefs.GetFloat(variableKey);
        player = GameObject.Find("player");
        this_obj = this.gameObject;
        scrollbar.onValueChanged.AddListener(delegate { OnScrollbarValueChanged(); });
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()   
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        yRot += h * 2* scrollbar.value;
        if(player!=this_obj)  xRot -= v * 2* scrollbar.value;;

        xRot = Mathf.Clamp(xRot, minVerticalAngle, maxVerticalAngle);
        transform.rotation = Quaternion.Euler(xRot, yRot, 0f);


    }
    public void OnScrollbarValueChanged()
    {
        PlayerPrefs.SetFloat(variableKey, scrollbar.value);
        PlayerPrefs.Save();
    }
}
