using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript4 : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // �����������I�u�W�F�N�g�̔z��
    public Vector2 spawnAreaRadius; // �I�u�W�F�N�g�𐶐�����͈͂̔��a
    private int nextObjectIndex = 0; // ���ɐ�������I�u�W�F�N�g�̃C���f�b�N�X
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime += 25f;
        }
    }
    void SpawnObject()
    {
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogWarning("No objects to spawn.");
            return;
        }

        GameObject objectToSpawn = objectsToSpawn[nextObjectIndex];
        float randomX = Random.Range(spawnAreaRadius.x, spawnAreaRadius.x);
        float randomY = Random.Range(spawnAreaRadius.y, spawnAreaRadius.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f) + transform.position; // �X�|�[���ʒu�����[���h���W�ɕϊ�
        Quaternion rotation = Quaternion.Euler(0, 180, 0);
        Instantiate(objectToSpawn, spawnPosition, rotation);
        nextObjectIndex++;
        if (nextObjectIndex >= objectsToSpawn.Length)
        {
            nextObjectIndex = 0; // �C���f�b�N�X���z��͈̔͊O�ɂȂ����ꍇ�A�ŏ��̗v�f�ɖ߂�
        }

    }
}
