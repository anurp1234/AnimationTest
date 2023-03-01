using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridPosition
{
    public int xPos;
    public int zPos;
    public GridPosition(int xPos, int zPos)
    {
        this.xPos = xPos;
        this.zPos = zPos;
    }

}
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    List<GameObject> gemsPrefabs;

    [SerializeField]
    List<GameObject> obstaclePrefabs;

    [SerializeField]
    int minGemCount = 5 ;

    [SerializeField]
    int maxGemCount = 10;

    [SerializeField]
    int minObstaclesCount = 10;

    [SerializeField]
    int maxObstaclesCount = 20;

    [SerializeField]
    int spawnRangeInX = 10;

    [SerializeField]
    int spawnRangeInZ = 10;

    [SerializeField]
    int zScaler = 1;

    [SerializeField]
    int xScaler = 1;

    List<GridPosition> gridPositions = new List<GridPosition>();

    void Start()
    {
        PopulatePositionGrid(spawnRangeInX, spawnRangeInZ);
        SpawnJewels();
        SpawnObstacles();
    }
    void PopulatePositionGrid(int maxX, int maxZ)
    {
        for (int x = 0; x < maxX; x++)
        {
            for (int z = 0; z < maxZ; z++)
            {
                gridPositions.Add(new GridPosition(x, z));
            }
        }
    }

    void SpawnJewels()
    {
        int jewelsCount = Random.Range(minGemCount, maxGemCount);
        int maxJewelIdx = gemsPrefabs.Count - 1;
        for (int i = 0; i < jewelsCount; i++)
        {
            int gridPos = Random.Range(0, gridPositions.Count);
            GridPosition pos = gridPositions[gridPos];
            gridPositions.RemoveAt(gridPos);
            float spawnXPos = pos.xPos * xScaler;
            float spawnZPos = pos.zPos * zScaler;

            int spawnJewelIdx = Random.Range(0, maxJewelIdx);
            float spawnYPos = gemsPrefabs[spawnJewelIdx].transform.position.y;

            GameObject.Instantiate(gemsPrefabs[spawnJewelIdx], new Vector3(spawnXPos, spawnYPos, spawnZPos), Quaternion.identity);
        }
    }

    void SpawnObstacles()
    {
        int obstaclesCount = Random.Range(minObstaclesCount, maxObstaclesCount);
        int maxIdx = obstaclePrefabs.Count - 1;
        for (int i = 0; i < obstaclesCount; i++)
        {
            int gridPos = Random.Range(0, gridPositions.Count);
            GridPosition pos = gridPositions[gridPos];
            gridPositions.RemoveAt(gridPos);
            float spawnXPos = pos.xPos * xScaler;
            float spawnZPos = pos.zPos * zScaler;
            int spawnIdx = Random.Range(0, maxIdx);
            float spawnYPos = obstaclePrefabs[spawnIdx].transform.position.y;
            GameObject.Instantiate(obstaclePrefabs[spawnIdx], new Vector3(spawnXPos, spawnYPos, spawnZPos), Quaternion.identity);
        }
    }
}
