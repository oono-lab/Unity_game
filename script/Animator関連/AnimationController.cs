using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    public TextMeshProUGUI displayText;
    public Transform targetObject;
    public string Talk = "Talk";
    public string Stand = "Stand";
    private Quaternion originalRotation;
    void Start()
    {
        animator = GetComponent<Animator>();
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (displayText.enabled==true)
        {
            animator.SetBool(Talk, true);
            animator.SetBool(Stand, false);
            Vector3 targetDirection = targetObject.position - transform.position;
            targetDirection.y = 0; // オブジェクトが上下に回転しないようにy方向の変化を無視
            Quaternion rotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = rotation;
        }
        else
        {
            animator.SetBool(Talk, false);
            animator.SetBool(Stand, true);
            transform.rotation = originalRotation;
        }
    }
}
