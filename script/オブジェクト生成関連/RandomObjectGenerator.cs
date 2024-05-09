using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour
{
    public List<GameObject> objectList;
    public int numberOfObjectsToGenerate = 6;
    private List<int> usedIndexes = new List<int>(); // 使用済みのインデックスを保持するリスト

    void Start()
    {
        GenerateRandomObjects();
    }

    void GenerateRandomObjects()
    {
        // 6つのGameObjectを生成する
        for (int i = 0; i < numberOfObjectsToGenerate; i++)
        {

            // ランダムなインデックスを選択する
            int randomIndex = GetUnusedRandomIndex();

            

            objectList[randomIndex].SetActive(true);


           
            // 使用済みのインデックスを記録する
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
        while (usedIndexes.Contains(randomIndex)); // 使用済みのインデックスであれば再度ランダムなインデックスを選択する

        return randomIndex;
    }
}
