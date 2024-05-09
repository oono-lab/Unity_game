using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript7 : MonoBehaviour
{
    // Start is called before the first frame update
    public string OtherObject = "OtherObject";
    public string humanObject = "humanObject";


    public float referenceX = 0.0f;

    
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision);
    }

    void HandleCollision(Collision collision)
    {
        // �Փ˂����Ώۂ����̃I�u�W�F�N�g�ł���ꍇ
        if (collision.gameObject.CompareTag(OtherObject))
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            if (Vector3.Dot(collisionNormal, transform.forward) < -0.9f)
            {
                float currentX = transform.position.x;

                if (currentX <= referenceX)
                {
                    // ���ɂ��炷
                    ShiftObject(-1.0f);
                }
                else
                {
                    // �E�ɂ��炷
                    ShiftObject(1.0f);
                }
            }
        }

        else if (collision.gameObject.CompareTag(humanObject))
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            if (Vector3.Dot(collisionNormal, transform.forward) < -0.9f)
            {
                float currentX = transform.position.x;

                if (currentX <= referenceX)
                {
                    // ���ɂ��炷
                    ShiftObject(-1.0f);
                }
                else
                {
                    // �E�ɂ��炷
                    ShiftObject(1.0f);
                }
            }
        }
        else
        {
            return;
        }
    }

    void ShiftObject(float direction)
    {
        // �ړ�����������w�肵�܂�
        Vector3 shiftDirection = transform.right * direction;

        // �ړ����鋗�����w�肵�܂�
        float shiftAmount = 1.0f;

        // ���̃t���[���ł̈ʒu���v�Z���܂�
        Vector3 nextPosition = transform.position + shiftDirection * shiftAmount;

        // ���̃t���[���ňʒu���X�V���܂�
        StartCoroutine(MoveToObject(nextPosition));
    }

    IEnumerator MoveToObject(Vector3 targetPosition)
    {
        float duration = 0.5f; // �ړ��ɂ����鎞�ԁi�b�j
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        // �w�肵�����ԓ��Ɉړ�������
        while (elapsedTime < duration)
        {   
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �ŏI�I�Ȉʒu��ݒ�
        transform.position = targetPosition;
        
        
    }
}
