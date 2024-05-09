using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour
{
    public List<GameObject> objectList;
    public int numberOfObjectsToGenerate = 6;
    private List<int> usedIndexes = new List<int>(); // �g�p�ς݂̃C���f�b�N�X��ێ����郊�X�g

    void Start()
    {
        GenerateRandomObjects();
    }

    void GenerateRandomObjects()
    {
        // 6��GameObject�𐶐�����
        for (int i = 0; i < numberOfObjectsToGenerate; i++)
        {

            // �����_���ȃC���f�b�N�X��I������
            int randomIndex = GetUnusedRandomIndex();

            

            objectList[randomIndex].SetActive(true);


           
            // �g�p�ς݂̃C���f�b�N�X���L�^����
            usedIndexes.Add(randomIndex);
        }
    }
    private int GetUnusedRandomIndex()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, objectList.Count);
        }
        while (usedIndexes.Contains(randomIndex)); // �g�p�ς݂̃C���f�b�N�X�ł���΍ēx�����_���ȃC���f�b�N�X��I������

        return randomIndex;
    }
}
