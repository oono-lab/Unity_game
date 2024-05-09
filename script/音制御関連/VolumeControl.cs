using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{

    public Transform target; // ���ʂ𒲐��������^�[�Q�b�g�I�u�W�F�N�g
    private AudioSource audioSource;
    public float maxDistance = 10f; // �ő勗��// Start is called before the first frame update
    void Start()
    {
        GameObject oni = this.gameObject;
        audioSource= oni.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector3.Distance(transform.position, target.position);
        // �ő勗�����̏ꍇ
        if (distance <= maxDistance)
        {
            // �����ɉ����ĉ��ʂ𒲐�
            float volume = 1f - (distance / maxDistance); // �ő勗���ɑ΂��銄��
            audioSource.volume = volume;
        }
        else
        {
            // �ő勗���𒴂����ꍇ�͉��ʂ�0�ɂ���
            audioSource.volume = 0f;
        }
    }
}
