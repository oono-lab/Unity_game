using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform; // �J������Transform
    public float shakeDuration = 0.5f; // �h��̎���
    public float shakeMagnitude = 0.5f; // �h��̋���

    private float initialPositionY; // ������Y���W
    private float shakeDurationRemaining = 0f; // �c��̗h�ꎞ��
    private Vector3 originalPosition; // �J�����̏����ʒu

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>(); // �J������Transform���ݒ肳��Ă��Ȃ��ꍇ�A�����I�Ɏ擾
        }
    }

    void Start()
    {
        originalPosition = cameraTransform.localPosition; // �J�����̏����ʒu��ۑ�
        initialPositionY = originalPosition.y; // Y���W�̏����ʒu��ۑ�
    }

    void Update()
    {
        if (shakeDurationRemaining > 0)
        {
            // �J�����������_���ɗh�炷
            float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
            Vector3 randomOffset = new Vector3(0f, offsetY, 0f);

            // �c��̗h�ꎞ�Ԃ����炷
            shakeDurationRemaining -= Time.deltaTime;
        }
        else
        {
            // �h�ꂪ�I��������A�J�����̈ʒu�������ʒu�ɖ߂�
            cameraTransform.localPosition = originalPosition;
        }
    }

    public void Shake()
    {
        shakeDurationRemaining = shakeDuration; // �h��̎��Ԃ�ݒ�
    }
}
