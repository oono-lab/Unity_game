using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript1 : MonoBehaviour
{
    float yRot;
    float xRot;
    float maxVerticalAngle = 40f; // è„å¸Ç´ÇÃç≈ëÂäpìx
    float minVerticalAngle = -40f; // â∫å¸Ç´ÇÃç≈ëÂäpìx
    public UnityEngine.UI.Scrollbar scrollbar;
    public float variableToModify;
    public string variableKey = "ScrollbarValue";
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(variableKey))
        {
            scrollbar.value = PlayerPrefs.GetFloat(variableKey);
        }
        scrollbar.onValueChanged.AddListener(delegate { OnScrollbarValueChanged(); });
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        yRot += h * 2* variableToModify;
        xRot -= v * 2* variableToModify;

        xRot = Mathf.Clamp(xRot, minVerticalAngle, maxVerticalAngle);
        transform.rotation = Quaternion.Euler(xRot, yRot, 0f);


    }
    public void OnScrollbarValueChanged()
    {
        variableToModify = scrollbar.value;
        PlayerPrefs.SetFloat(variableKey, scrollbar.value);
        PlayerPrefs.Save();
    }
}
