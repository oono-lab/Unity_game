using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript5 : MonoBehaviour
{
    // Start is called before the first frame update
    private float lastZ; // �O���z���̒l
    private float timer; // �o�ߎ���
    public float thresholdZ = 1.0f;
    public float thresholdZ1 = 1.0f;
    public GameObject object1;
    void Start()
    {
        // ������

        lastZ = transform.position.z;
        timer = 0f;
        
        // ����z���W��臒l

    }

void Update()
    {
        // z���̒l��1�̈ʂ��ω����Ȃ������ꍇ
        if (Mathf.FloorToInt(transform.position.z) % 10 == Mathf.FloorToInt(lastZ) % 10)
        {
            // �o�ߎ��Ԃ����Z
            timer += Time.deltaTime;

            // �o�ߎ��Ԃ�5�b�ȏ�o�߂����ꍇ
            if (timer >= 5.0f)
            {
                // �I�u�W�F�N�g������
                Destroy(gameObject);
            }
        }
        else
        {
            // z���̒l���ω������ꍇ�͌o�ߎ��Ԃ����Z�b�g
            timer = 0f;
        }
        
        // ���݂�z���̒l���X�V
        lastZ = transform.position.z;
        if ((lastZ > thresholdZ1) || (lastZ < thresholdZ))
        {
            // �I�u�W�F�N�g������
            Destroy(gameObject);
        }
    }
}
