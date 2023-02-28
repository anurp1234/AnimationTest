using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> gemsPrefabs;

    [SerializeField]
    int minGemCount = 5 ;
    [SerializeField]
    int maxGemCount = 10;

    [SerializeField]
    float spawnRangeInX = 10;

    [SerializeField]
    float spawnRangeInZ = 10;

    [SerializeField]
    float spawnYPos = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnJewels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnJewels()
    {
        int jewelsCount = Random.Range(minGemCount, maxGemCount);

        int maxJewelIdx = gemsPrefabs.Count - 1;
        for (int i = 0; i < jewelsCount; i++)
        {
            float spawnXPos = Random.Range(-spawnRangeInX, spawnRangeInX);
            float spawnZPos = Random.Range(-spawnRangeInZ, spawnRangeInZ);

            int spawnJewelIdx = Random.Range(0, maxJewelIdx);

            GameObject.Instantiate(gemsPrefabs[spawnJewelIdx], new Vector3(spawnXPos, spawnYPos, spawnZPos), Quaternion.identity);
        }
    }
}
