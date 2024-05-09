using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NewBehaviourScript9 : MonoBehaviour
{
    public Outline outline; // �A�E�g���C����\�����邽�߂̃R���|�[�l���g

    private void Start()
    {
        outline.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // �Փ˂����I�u�W�F�N�g������̃^�O�������Ă���ꍇ�ɏ������s��
        if (other.CompareTag("TargetTag"))
        {
            outline.enabled = true;
            // �A�E�g���C�����\���ɂ���

        }
    }

    void OnTriggerExit(Collider other)
    {
        // �Փ˂��Ă����I�u�W�F�N�g�����ꂽ�ꍇ�ɏ������s��
        if (other.CompareTag("TargetTag"))
        {
            outline.enabled = false;
            // �A�E�g���C�����Ăѕ\������
            
        }
    }
}
