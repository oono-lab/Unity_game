using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telop : MonoBehaviour
{
    [SerializeField]
    RectTransform[] telops;

    [SerializeField]
    RectTransform endPoint;

    void Update()
    {
        for (int i = 0; i < telops.Length; i++)
        {
            if (Input.GetKey(KeyCode.Space)) telops[i].localPosition += (Vector3.up * .9f)*9;
            else telops[i].localPosition += Vector3.up * .9f;


            if ((telops[i].localPosition.y > endPoint.localPosition.y)&&i== telops.Length-1)
            {
                Cursor.lockState = CursorLockMode.None;
                FadeManager.Instance.LoadScene("title 1", 1.0f);
            }
        }
    }
}
