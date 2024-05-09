using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NewBehaviourScript3 : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // 生成したいオブジェクトの配列
    public Vector2 spawnAreaRadius; // オブジェクトを生成する範囲の半径
    private int nextObjectIndex = 0; // 次に生成するオブジェクトのインデックス
    private float nextSpawnTime;
    public GameObject instantiatedObject;
    private GameObject[] objectsTodelete = { };
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
        if (objectsToSpawn.Contains(null))
        {
            Debug.LogWarning("No objects to spawn.");
            return;
        }

        GameObject objectToSpawn = objectsToSpawn[nextObjectIndex];
        float randomX = Random.Range(spawnAreaRadius.x, spawnAreaRadius.x);
        float randomY = Random.Range(spawnAreaRadius.y, spawnAreaRadius.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f) + transform.position; // スポーン位置をワールド座標に変換
        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        
        //Instantiate(objectToSpawn, spawnPosition, rotation);
        instantiatedObject = Instantiate(objectToSpawn, spawnPosition, rotation);
        nextObjectIndex++;
        if (nextObjectIndex >= objectsToSpawn.Length)
        {
            nextObjectIndex = 0; // インデックスが配列の範囲外になった場合、最初の要素に戻る
        }

    }
}
